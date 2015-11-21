using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using System.Threading;

namespace SelfPatch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //args = "p 6272 f DPRENALauncher2.exe".Split(' ');

                Process P = null;
                string patchfile = "";
                for (int x = 0; x < args.Length; x++)
                {
                    string arg = args[x];
                    if (arg == "p")
                    {
                        P = Process.GetProcessById(int.Parse(args[x + 1]));
                        x++;
                    }
                    if (arg == "f")
                    {
                        patchfile = args[x + 1];
                        x++;
                    }
                }
                if (patchfile != null && P != null)
                {
                    P.Kill();
                    P.WaitForExit();
                    Thread.Sleep(500);
                    string p2 = patchfile.Replace("2", "");
                    File.Delete(p2);
                    Thread.Sleep(500);
                    FileInfo FI = new FileInfo(patchfile);
                    if (FI.Length < 1000)
                        throw new Exception("P2 is too small");
                    FI.CopyTo(p2);
                    Thread.Sleep(500);
                    File.Delete(patchfile);
                    Process.Start(p2);
                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message + "\n\n" + E.StackTrace);
                
            }
        }
    }
}
