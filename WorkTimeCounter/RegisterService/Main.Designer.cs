namespace RegisterService
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
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLogInfo = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonUnInstall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServiceName.Location = new System.Drawing.Point(83, 24);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(277, 21);
            this.textBoxServiceName.TabIndex = 2;
            this.textBoxServiceName.TextChanged += new System.EventHandler(this.textBoxServiceName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя";
            // 
            // labelLogInfo
            // 
            this.labelLogInfo.AutoSize = true;
            this.labelLogInfo.Location = new System.Drawing.Point(104, 48);
            this.labelLogInfo.Name = "labelLogInfo";
            this.labelLogInfo.Size = new System.Drawing.Size(55, 14);
            this.labelLogInfo.TabIndex = 4;
            this.labelLogInfo.Text = "Служба";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.BackColor = System.Drawing.Color.White;
            this.textBoxFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFileName.Location = new System.Drawing.Point(3, 3);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(277, 21);
            this.textBoxFileName.TabIndex = 5;
            this.textBoxFileName.DoubleClick += new System.EventHandler(this.Browse_click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(284, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Browse_click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Exe files|*.exe";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonUnInstall);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.textBoxFileName);
            this.panel1.Controls.Add(this.buttonRun);
            this.panel1.Controls.Add(this.buttonInstall);
            this.panel1.Location = new System.Drawing.Point(19, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 118);
            this.panel1.TabIndex = 7;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInstall.Enabled = false;
            this.buttonInstall.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonInstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonInstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstall.Location = new System.Drawing.Point(3, 62);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(99, 23);
            this.buttonInstall.TabIndex = 1;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRun.Enabled = false;
            this.buttonRun.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRun.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonRun.Location = new System.Drawing.Point(112, 62);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(99, 23);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.ForeColor = System.Drawing.Color.Red;
            this.buttonStop.Location = new System.Drawing.Point(112, 90);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(99, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonUnInstall
            // 
            this.buttonUnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUnInstall.Enabled = false;
            this.buttonUnInstall.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonUnInstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonUnInstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonUnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnInstall.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonUnInstall.Location = new System.Drawing.Point(3, 90);
            this.buttonUnInstall.Name = "buttonUnInstall";
            this.buttonUnInstall.Size = new System.Drawing.Size(99, 23);
            this.buttonUnInstall.TabIndex = 5;
            this.buttonUnInstall.Text = "UnInstall";
            this.buttonUnInstall.UseVisualStyleBackColor = true;
            this.buttonUnInstall.Click += new System.EventHandler(this.buttonUnInstall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Состояние";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelLogInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxServiceName);
            this.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление службой";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxServiceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelLogInfo;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonUnInstall;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label label1;
    }
}