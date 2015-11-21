namespace DPRENALauncher
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.TmrTick = new System.Windows.Forms.Timer(this.components);
            this.LblTotalProgress = new System.Windows.Forms.Label();
            this.BarCurrent = new DPRENALauncher.Classes.Bar();
            this.BarTotal = new DPRENALauncher.Classes.Bar();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
            this.SuspendLayout();
            // 
            // pbClose
            // 
            this.pbClose.Image = global::DPRENALauncher.Properties.Resources.x_off;
            this.pbClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbClose.Location = new System.Drawing.Point(565, 4);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(25, 25);
            this.pbClose.TabIndex = 2;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            this.pbClose.MouseEnter += new System.EventHandler(this.pbClose_MouseEnter);
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            // 
            // pbMinimize
            // 
            this.pbMinimize.Image = global::DPRENALauncher.Properties.Resources.minimize_off;
            this.pbMinimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbMinimize.Location = new System.Drawing.Point(534, 4);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(25, 25);
            this.pbMinimize.TabIndex = 3;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.Click += new System.EventHandler(this.pbMinimize_Click);
            this.pbMinimize.MouseEnter += new System.EventHandler(this.pbMinimize_MouseEnter);
            this.pbMinimize.MouseLeave += new System.EventHandler(this.pbMinimize_MouseLeave);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.lblHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHeader.Location = new System.Drawing.Point(16, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(132, 20);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "DPDragonFang Launcher";
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.lblStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStatus.Location = new System.Drawing.Point(17, 447);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(95, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Enter credentials...";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // pbStart
            // 
            this.pbStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.pbStart.Image = global::DPRENALauncher.Properties.Resources.wait;
            this.pbStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbStart.Location = new System.Drawing.Point(428, 457);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(157, 48);
            this.pbStart.TabIndex = 8;
            this.pbStart.TabStop = false;
            this.pbStart.Click += new System.EventHandler(this.pbStart_Click);
            this.pbStart.MouseEnter += new System.EventHandler(this.pbStart_MouseEnter);
            this.pbStart.MouseLeave += new System.EventHandler(this.pbStart_MouseLeave);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.lblProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProgress.Location = new System.Drawing.Point(393, 449);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(21, 13);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "0%";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TmrTick
            // 
            this.TmrTick.Enabled = true;
            this.TmrTick.Interval = 10;
            this.TmrTick.Tick += new System.EventHandler(this.TmrTick_Tick);
            // 
            // LblTotalProgress
            // 
            this.LblTotalProgress.AutoSize = true;
            this.LblTotalProgress.BackColor = System.Drawing.Color.Transparent;
            this.LblTotalProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.LblTotalProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalProgress.Location = new System.Drawing.Point(208, 495);
            this.LblTotalProgress.Name = "LblTotalProgress";
            this.LblTotalProgress.Size = new System.Drawing.Size(21, 13);
            this.LblTotalProgress.TabIndex = 13;
            this.LblTotalProgress.Text = "0%";
            this.LblTotalProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarCurrent
            // 
            this.BarCurrent.Location = new System.Drawing.Point(19, 465);
            this.BarCurrent.Max = 100;
            this.BarCurrent.Name = "BarCurrent";
            this.BarCurrent.Size = new System.Drawing.Size(395, 19);
            this.BarCurrent.TabIndex = 17;
            this.BarCurrent.Value = 0;
            // 
            // BarTotal
            // 
            this.BarTotal.Location = new System.Drawing.Point(19, 493);
            this.BarTotal.Max = 100;
            this.BarTotal.Name = "BarTotal";
            this.BarTotal.Size = new System.Drawing.Size(395, 19);
            this.BarTotal.TabIndex = 15;
            this.BarTotal.Value = 0;
            // 
            // UserNameBox
            // 
            this.UserNameBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.UserNameBox.ForeColor = System.Drawing.Color.Transparent;
            this.UserNameBox.Location = new System.Drawing.Point(428, 366);
            this.UserNameBox.MaxLength = 32;
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(100, 20);
            this.UserNameBox.TabIndex = 18;
            this.UserNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.PasswordBox.ForeColor = System.Drawing.Color.Transparent;
            this.PasswordBox.Location = new System.Drawing.Point(428, 392);
            this.PasswordBox.MaxLength = 32;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 19;
            this.PasswordBox.UseSystemPasswordChar = true;
            this.PasswordBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(354, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(354, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DPRENALauncher.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.BarCurrent);
            this.Controls.Add(this.LblTotalProgress);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbStart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pbMinimize);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.BarTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Main";
            this.Text = "SoulHunterZ Launcher";
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbMinimize;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblProgress;
        public System.Windows.Forms.PictureBox pbStart;
        private System.Windows.Forms.Timer TmrTick;
        public System.Windows.Forms.Label LblTotalProgress;
        public Classes.Bar BarTotal;
        public Classes.Bar BarCurrent;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}

