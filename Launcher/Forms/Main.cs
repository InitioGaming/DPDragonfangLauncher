using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net;

namespace DPRENALauncher
{

    public partial class Main : Form
    {

        //Settings
        private static string GUNZ_EXE = "dp_x64.exe";
        [DllImport("KERNEL32.DLL", EntryPoint = "GetProfileStringW",
         SetLastError = true,
         CharSet = CharSet.Unicode, ExactSpelling = true,
         CallingConvention = CallingConvention.StdCall)]
        private static extern int GetProfileString(
          string lpAppName,
          string lpKeyName,
          string lpDefault,
          string lpReturnString,
          int nSize);
        [DllImport("KERNEL32.DLL", EntryPoint = "WriteProfileStringW",
          SetLastError = true,
          CharSet = CharSet.Unicode, ExactSpelling = true,
          CallingConvention = CallingConvention.StdCall)]
        private static extern int WriteProfileString(
          string lpAppName,
          string lpKeyName,
          string lpString);
        //Moving Control
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            int WM_NCHITTEST = 0x84;
            if (m.Msg == WM_NCHITTEST)
            {
                int HTCLIENT = 1;
                int HTCAPTION = 2;
                if (m.Result.ToInt32() == HTCLIENT)
                    m.Result = (IntPtr)HTCAPTION;
            }
        }

        public int BarTotalVal = 0;
        public int BarCurVal = 0;
        public string Status = "Enter credentials and server...";
        public string Perc = "";
        public int BarTotalMax = 100;
        public int BarCurMax = 100;
        public string PercTotal = "";

        private void TmrTick_Tick(object sender, EventArgs e)
        {
            try
            {

                if (BarTotalMax != BarTotal.Max)
                    BarTotal.Max = BarTotalMax;
                if (BarCurMax != BarCurrent.Max)
                    BarCurrent.Max = BarCurMax;

                if (BarTotalVal != BarTotal.Value)
                    BarTotal.Value = BarTotalVal;
                if (BarCurVal != BarCurrent.Value)
                    BarCurrent.Value = BarCurVal;

                if (lblStatus.Text != Status)
                    lblStatus.Text = Status;
                if (lblProgress.Text != Perc)
                    lblProgress.Text = Perc;
                if (LblTotalProgress.Text != PercTotal)
                    LblTotalProgress.Text = PercTotal;
            }
            catch
            { }

        }

        public Main()
        {
            InitializeComponent();
            try
            {
                Process P = Process.GetProcessesByName("SelfPatch")[0];
                P.Kill();
            }
            catch
            { }
            Classes.DPRENALauncher.initialize(this);
            UserNameBox.Text = GetIniFileString("Connect Info", "id", " ");
            PasswordBox.Text = GetIniFileString("Connect Info", "password", " ");
        }

        private static string GetIniFileString(string category, string key, string defaultValue)
        {
            string returnString = new string(' ', 1024);
            GetProfileString(category, key, defaultValue, returnString, 1024);
            return returnString.Split('\0')[0];
        }
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbMinimize_MouseEnter(object sender, EventArgs e)
        {
            Classes.DPRENALauncher.changeImage(pbMinimize, "minimize_on.png");
        }

        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
            Classes.DPRENALauncher.changeImage(pbMinimize, "minimize_off.png");
        }

        private void pbClose_MouseEnter(object sender, EventArgs e)
        {
            Classes.DPRENALauncher.changeImage(pbClose, "x_on.png");
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            Classes.DPRENALauncher.changeImage(pbClose, "x_off.png");
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbStart_MouseEnter(object sender, EventArgs e)
        {
            if (pbStart.Tag != null)
            {
                Classes.DPRENALauncher.changeImage(pbStart, "start_on.png");
            }
        }

        private void pbStart_MouseLeave(object sender, EventArgs e)
        {
            if (pbStart.Tag != null)
            {
                Classes.DPRENALauncher.changeImage(pbStart, "start_off.png");
            }
        }

        static class Imports
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);


            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }

        class SerialKey
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            private delegate bool MakeSerialKey();

            public static bool Create()
            {
                IntPtr module = Imports.LoadLibrary("SKGen.dll");
                IntPtr function = Imports.GetProcAddress(module, "MakeSerialKey");

                MakeSerialKey serialKey = (MakeSerialKey)Marshal.GetDelegateForFunctionPointer(function, typeof(MakeSerialKey));
                bool success = serialKey();
                Imports.FreeLibrary(module);

                return success;
            }
        }

        public string CreateMD5Hash(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                // sb.Append(hashBytes[i].ToString("x2")); 
            }
            return sb.ToString();
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            if (UserNameBox.Text.Length >= 3 && PasswordBox.Text.Length >= 3)
            {
                MD5 md5;

                //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
                md5 = new MD5CryptoServiceProvider();
                Process.Start(GUNZ_EXE, "-trans_userinfo " + UserNameBox.Text + " " + PasswordBox.Text); //GAMESRV + " " + UserNameBox.Text + " " + CreateMD5Hash(PasswordBox.Text.ToString()));
                //Process.Start(GUNZ_EXE, "launch " + UserNameBox.Text + " " + PasswordBox.Text.ToString() + " " + " " + "skip_sel_world");
                Close();
            }
            else if (UserNameBox.Text.Length < 3 && lblStatus.Text == "Client is up to date !")
            {
                MessageBox.Show("Usernames must be more than 2 characters.");
            }
            else if (PasswordBox.Text.Length < 3 && lblStatus.Text == "Client is up to date !")
            {
                MessageBox.Show("Passwords must be more than 2 characters.");
            }
            else
            {
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            WriteProfileString("Connect Info", "id", UserNameBox.Text);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            WriteProfileString("Connect Info", "password", PasswordBox.Text);
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
          //  WriteProfileString("Connect Info", "server", ServerBox.Text);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }




        
    }
}
