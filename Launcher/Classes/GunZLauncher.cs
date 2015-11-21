using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace DPRENALauncher.Classes
{
    class DPRENALauncher
    {
        private static System.Drawing.Text.PrivateFontCollection m_pPrivateFontCollection;

        static Main main;
        public static void initialize(Main pMain)
        {
            m_pPrivateFontCollection = new System.Drawing.Text.PrivateFontCollection();
            System.IO.Stream pStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DPRENALauncher.Resources.taile.ttf");

            if (pStream != null)
            {
                using (pStream)
                {
                    byte[] byStream = new byte[pStream.Length];
                    pStream.Read(byStream, 0, byStream.Length);

                    unsafe
                    {
                        fixed (byte* pFontData = byStream)
                        {
                            m_pPrivateFontCollection.AddMemoryFont((IntPtr)pFontData, byStream.Length);
                        }
                    }
                }

                pMain.lblHeader.Font = new System.Drawing.Font(m_pPrivateFontCollection.Families[0], 9, System.Drawing.FontStyle.Regular);
                pMain.lblStatus.Font = new System.Drawing.Font(m_pPrivateFontCollection.Families[0], 8, System.Drawing.FontStyle.Regular);
            }
            main = pMain;
            Thread T = new Thread(new ThreadStart(PatchThread));
            T.IsBackground = true;
            T.Start();
        }
        public static void PatchThread()
        {
            Updater.initialize(main);
        }

        public static void changeImage(System.Windows.Forms.PictureBox pPictureBox, string strImage)
        {
            System.IO.Stream pStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DPRENALauncher.Resources." + strImage);

            if (pStream != null)
            {
                using (pStream)
                {
                    pPictureBox.Image = System.Drawing.Image.FromStream(pStream);
                    pPictureBox.Tag = strImage;
                }
            }
        }
    }
}
