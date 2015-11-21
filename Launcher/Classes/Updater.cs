using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;


namespace DPRENALauncher.Classes
{
    class Updater
    {
        private static Main m_pMain;
        private static CGWebClient m_pWebClient;
        private static List<string> m_pUpdateList = new List<string>();
        private static List<int> Sizes = new List<int>();
        private static string WEBSITE = "http://patch.dpdragonfang.com/";
        private static bool PatchSelf = false;

        public static void initialize(Main pMain)
        {
            m_pMain = pMain;
            m_pWebClient = new CGWebClient();
            m_pWebClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(m_pWebClient_DownloadFileCompleted);
            m_pWebClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(m_pWebClient_DownloadProgressChanged);

            if (!System.IO.File.Exists(@"pak\Files\tile.p000"))
                m_pWebClient.DownloadFile(WEBSITE + "launcher/new_patch.xml", "patch.xml");
            else if (!System.IO.File.Exists(@"pak\World\_test$sample_1.p000"))
                m_pWebClient.DownloadFile(WEBSITE + "launcher/new_patch.xml", "patch.xml");
            else
                m_pWebClient.DownloadFile(WEBSITE + "launcher/patch.xml", "patch.xml");

            try
            {
                using (System.Xml.XmlTextReader pXmlTextReader = new System.Xml.XmlTextReader(Directory.GetCurrentDirectory() + "/patch.xml"))
                //using (System.Xml.XmlTextReader pXmlTextReader = new System.Xml.XmlTextReader( WEBSITE + "files/patch.xml"))
                {
                    int x = 0;

                    while (pXmlTextReader.ReadToFollowing("PATCHNODE"))
                    {
                        x++;
                        m_pMain.Status = "Interpreting Patch Information " + x + "...";
                        if (pXmlTextReader.MoveToFirstAttribute())
                        {
                            string strFilename = pXmlTextReader.GetAttribute("file").Replace("./", "");
                            string strCurrDir = System.IO.Directory.GetCurrentDirectory();
                            try
                            {
                                string Dir = Path.GetDirectoryName(strFilename);
                                if (!Directory.Exists(Dir) && Dir != "")
                                    Directory.CreateDirectory(Dir);
                            }
                            catch
                            {
                                m_pMain.Status = "Failed to create or read folder info.";
                            }
                            //foreach (string strTemp in strFilename.Split('/'))
                            //{
                            //    if (!strTemp.Contains("."))
                            //    {
                            //        System.IO.Directory.CreateDirectory(strTemp);
                            //        continue;
                            //    }
                            //}

                            uint nChecksum = 0;

                            if (pXmlTextReader.ReadToFollowing("CHECKSUM"))
                            {
                                nChecksum = (uint)pXmlTextReader.ReadElementContentAs(typeof(uint), null);
                            }
                            try
                            {
                                FileInfo FI = new FileInfo(strFilename);
                                if (strFilename.ToLower() == Path.GetFileName(Application.ExecutablePath).ToLower())
                                {
                                    FileInfo FI2 = new FileInfo(strFilename + "_");
                                    if (FI2.Exists)
                                        FI2.Delete();
                                    Thread.Sleep(500);
                                    FI.CopyTo(strFilename + "_");
                                    uint crc = getFileCrc(strFilename + "_");
                                    FI2 = new FileInfo(strFilename + "_");
                                    if (FI2.Exists)
                                        FI2.Delete();
                                    if (crc != nChecksum)
                                    {
                                        PatchSelf = true;
                                        m_pUpdateList.Add(strFilename);
                                    }
                                    continue;
                                }
                                if (!FI.Exists)
                                    m_pUpdateList.Add(strFilename);
                                else
                                {
                                    uint crc = getFileCrc(strFilename);
                                    if (crc != nChecksum)
                                    {
                                        m_pUpdateList.Add(strFilename);
                                    }
                                }
                            }
                            catch (Exception E)
                            {
                                if (E.Message.Contains("msvcr71.dll' because it is being used by another process"))
                                {
                                    //ignore because it's used by .net and gunz needs it...  note that this is a possible abuse for exploitation
                                }
                                else
                                {
                                    MessageBox.Show("Some of the files (" + strFilename + ") that need to be patched/edited are currently in use.  Make sure SoulHunterZ is closed.  If this error persists, restart your computer.", "Fatal Error");
                                    Application.Exit();
                                }
                            }

                            System.IO.Directory.SetCurrentDirectory(strCurrDir);
                        }
                    }
                }
            }
            catch
            {
                m_pMain.Status = "Failed to get or read patch info.";
                m_pWebClient.Dispose();
                return;
            }

            m_pMain.BarTotalMax = m_pUpdateList.Count;
            m_pMain.BarTotalVal = m_pMain.BarTotalMax;
            m_pMain.BarCurVal = m_pMain.BarCurMax;
            updateNext();
        }

        static void m_pWebClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            m_pMain.Status = "Updating file " + e.UserState + " (" + (e.BytesReceived / 1024) + "/ " + (e.TotalBytesToReceive / 1024) + " KB)";

            m_pMain.Perc = e.ProgressPercentage + "%";
            m_pMain.BarCurMax = (int)(e.TotalBytesToReceive / 1024);
            m_pMain.BarCurVal = (int)(e.BytesReceived / 1024);

        }

        static void m_pWebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                m_pMain.Status= "Failed to update file " + e.UserState;
                return;
            }

            m_pUpdateList.Remove(e.UserState.ToString());
            if (e.UserState.ToString().ToLower() == Path.GetFileName(Application.ExecutablePath).ToLower().Replace(".exe", "2.exe"))
            {
                m_pMain.Status = "Patching self.  Please wait.";
                Thread T = new Thread(new ThreadStart(PatchThread));
                T.IsBackground = true;
                SPN = e.UserState.ToString();
                T.Start();
            }else
                updateNext();
        }
        static string SPN = "";
        static bool endthread = false;
        static void PatchThread()
        {
            try
            {
                try
                {
                    Process.GetProcessesByName("SelfPatch")[0].Kill();
                }
                catch
                {
                    
                }
                if (File.Exists("SelfPatch.exe"))
                    File.Delete("SelfPatch.exe");
                File.WriteAllBytes("SelfPatch.exe", Properties.Resources.SelfPatch);
                Thread.Sleep(1000);
                string args = "p " + Process.GetCurrentProcess().Id + " f " + SPN;
                Process.Start("SelfPatch.exe", args);
            }
            catch
            {
                MessageBox.Show("File in use.  If this error persists, restart your computer.","Error");
            }
            //endthread = true;
        }

        public static void downloadFile(string strFile)
        {
            m_pMain.Status= "Updating file " + strFile + "...";
            int test = 0;
            test++;
            if (strFile.ToLower() == Path.GetFileName(Application.ExecutablePath).ToLower())
            {
                strFile = Path.GetFileNameWithoutExtension(strFile) + "2.exe";

                m_pWebClient.DownloadFileAsync(new Uri(WEBSITE + "launcher/" + strFile.Replace("2.exe", ".exe")), strFile, strFile);
            }
            else
                m_pWebClient.DownloadFileAsync(new Uri(WEBSITE + "files/" + strFile), strFile, strFile);
        }


        static int index = 0;
        private static void updateNext()
        {
            if (m_pUpdateList.Count > 0)
            {
                downloadFile(m_pUpdateList[0]);
                index++;
                int Perc = ((index * 100) / m_pMain.BarTotalMax);
                m_pMain.PercTotal = Perc + "%";
                m_pMain.BarTotalVal = index;
            }
            else
            {
                m_pMain.Perc = "";
                m_pMain.Status= "Client is up to date !";
                m_pMain.PercTotal = "";
                m_pMain.BarTotalVal = m_pMain.BarTotalMax;
                m_pMain.BarCurVal = m_pMain.BarCurMax;
                File.Delete(Directory.GetCurrentDirectory() + "/patch.xml");
                DPRENALauncher.changeImage(m_pMain.pbStart, "start_off.png");
            }
        }

        private static uint getFileCrc(string strFilename)
        {
            if (!System.IO.File.Exists(strFilename))
            {
                return 0;
            }

            using (Crc32 pCRC32 = new Crc32())
            {
                byte[] retb;
                using (System.IO.FileStream pFileStream = System.IO.File.Open(strFilename, System.IO.FileMode.Open))
                {
                    retb = pCRC32.ComputeHash(pFileStream);
                }
                
                string s = "";
                foreach (byte b in retb)
                    s += b.ToString("x2").ToLower();

                uint ret = UInt32.Parse(s, System.Globalization.NumberStyles.HexNumber);
                return ret;
            }
        }
    }
}
