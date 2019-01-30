namespace WorkTimeTray
{
    partial class Settings
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelUpdateTime = new System.Windows.Forms.Panel();
            this.textBoxUpdateTime = new System.Windows.Forms.TextBox();
            this.labelUpdateTime = new System.Windows.Forms.Label();
            this.errorProviderNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelDay = new System.Windows.Forms.Panel();
            this.textBoxDay = new System.Windows.Forms.TextBox();
            this.labelDay = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.panelBackgorund = new System.Windows.Forms.Panel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.labelBackgound = new System.Windows.Forms.Label();
            this.panelLogFite = new System.Windows.Forms.Panel();
            this.buttonLogFile = new System.Windows.Forms.Button();
            this.textBoxLogFile = new System.Windows.Forms.TextBox();
            this.labelLogFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelUpdateTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNumber)).BeginInit();
            this.panelDay.SuspendLayout();
            this.panelBackgorund.SuspendLayout();
            this.panelLogFite.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(314, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(233, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelUpdateTime
            // 
            this.panelUpdateTime.Controls.Add(this.textBoxUpdateTime);
            this.panelUpdateTime.Controls.Add(this.labelUpdateTime);
            this.panelUpdateTime.Location = new System.Drawing.Point(13, 13);
            this.panelUpdateTime.Name = "panelUpdateTime";
            this.panelUpdateTime.Size = new System.Drawing.Size(200, 50);
            this.panelUpdateTime.TabIndex = 2;
            // 
            // textBoxUpdateTime
            // 
            this.textBoxUpdateTime.Location = new System.Drawing.Point(7, 21);
            this.textBoxUpdateTime.MaxLength = 4;
            this.textBoxUpdateTime.Name = "textBoxUpdateTime";
            this.textBoxUpdateTime.Size = new System.Drawing.Size(61, 20);
            this.textBoxUpdateTime.TabIndex = 1;
            this.textBoxUpdateTime.TextChanged += new System.EventHandler(this.VerText);
            // 
            // labelUpdateTime
            // 
            this.labelUpdateTime.AutoSize = true;
            this.labelUpdateTime.Location = new System.Drawing.Point(4, 4);
            this.labelUpdateTime.Name = "labelUpdateTime";
            this.labelUpdateTime.Size = new System.Drawing.Size(64, 13);
            this.labelUpdateTime.TabIndex = 0;
            this.labelUpdateTime.Text = "Update time";
            // 
            // errorProviderNumber
            // 
            this.errorProviderNumber.ContainerControl = this;
            // 
            // panelDay
            // 
            this.panelDay.Controls.Add(this.textBoxDay);
            this.panelDay.Controls.Add(this.labelDay);
            this.panelDay.Location = new System.Drawing.Point(12, 69);
            this.panelDay.Name = "panelDay";
            this.panelDay.Size = new System.Drawing.Size(200, 50);
            this.panelDay.TabIndex = 3;
            // 
            // textBoxDay
            // 
            this.textBoxDay.Location = new System.Drawing.Point(8, 20);
            this.textBoxDay.MaxLength = 4;
            this.textBoxDay.Name = "textBoxDay";
            this.textBoxDay.Size = new System.Drawing.Size(62, 20);
            this.textBoxDay.TabIndex = 1;
            this.textBoxDay.TextChanged += new System.EventHandler(this.VerText);
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(4, 4);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(58, 13);
            this.labelDay.TabIndex = 0;
            this.labelDay.Text = "Day length";
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(39, 20);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(75, 23);
            this.buttonBackground.TabIndex = 4;
            this.buttonBackground.Text = "Select...";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // panelBackgorund
            // 
            this.panelBackgorund.Controls.Add(this.panelColor);
            this.panelBackgorund.Controls.Add(this.labelBackgound);
            this.panelBackgorund.Controls.Add(this.buttonBackground);
            this.panelBackgorund.Location = new System.Drawing.Point(12, 125);
            this.panelBackgorund.Name = "panelBackgorund";
            this.panelBackgorund.Size = new System.Drawing.Size(200, 50);
            this.panelBackgorund.TabIndex = 5;
            // 
            // panelColor
            // 
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Location = new System.Drawing.Point(8, 20);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(25, 23);
            this.panelColor.TabIndex = 6;
            // 
            // labelBackgound
            // 
            this.labelBackgound.AutoSize = true;
            this.labelBackgound.Location = new System.Drawing.Point(7, 4);
            this.labelBackgound.Name = "labelBackgound";
            this.labelBackgound.Size = new System.Drawing.Size(91, 13);
            this.labelBackgound.TabIndex = 5;
            this.labelBackgound.Text = "Background color";
            // 
            // panelLogFite
            // 
            this.panelLogFite.Controls.Add(this.buttonLogFile);
            this.panelLogFite.Controls.Add(this.textBoxLogFile);
            this.panelLogFite.Controls.Add(this.labelLogFile);
            this.panelLogFite.Location = new System.Drawing.Point(13, 181);
            this.panelLogFite.Name = "panelLogFite";
            this.panelLogFite.Size = new System.Drawing.Size(200, 50);
            this.panelLogFite.TabIndex = 4;
            // 
            // buttonLogFile
            // 
            this.buttonLogFile.Location = new System.Drawing.Point(122, 17);
            this.buttonLogFile.Name = "buttonLogFile";
            this.buttonLogFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLogFile.TabIndex = 7;
            this.buttonLogFile.Text = "Browse...";
            this.buttonLogFile.UseVisualStyleBackColor = true;
            this.buttonLogFile.Click += new System.EventHandler(this.buttonLogFile_Click);
            // 
            // textBoxLogFile
            // 
            this.textBoxLogFile.Location = new System.Drawing.Point(8, 20);
            this.textBoxLogFile.MaxLength = 255;
            this.textBoxLogFile.Name = "textBoxLogFile";
            this.textBoxLogFile.ReadOnly = true;
            this.textBoxLogFile.Size = new System.Drawing.Size(108, 20);
            this.textBoxLogFile.TabIndex = 1;
            // 
            // labelLogFile
            // 
            this.labelLogFile.AutoSize = true;
            this.labelLogFile.Location = new System.Drawing.Point(4, 4);
            this.labelLogFile.Name = "labelLogFile";
            this.labelLogFile.Size = new System.Drawing.Size(62, 13);
            this.labelLogFile.TabIndex = 0;
            this.labelLogFile.Text = "Path log file";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "json|*.json";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 450);
            this.Controls.Add(this.panelLogFite);
            this.Controls.Add(this.panelBackgorund);
            this.Controls.Add(this.panelDay);
            this.Controls.Add(this.panelUpdateTime);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Name = "Settings";
            this.Text = "Settings";
            this.panelUpdateTime.ResumeLayout(false);
            this.panelUpdateTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNumber)).EndInit();
            this.panelDay.ResumeLayout(false);
            this.panelDay.PerformLayout();
            this.panelBackgorund.ResumeLayout(false);
            this.panelBackgorund.PerformLayout();
            this.panelLogFite.ResumeLayout(false);
            this.panelLogFite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelUpdateTime;
        private System.Windows.Forms.Label labelUpdateTime;
        private System.Windows.Forms.ErrorProvider errorProviderNumber;
        private System.Windows.Forms.Panel panelDay;
        private System.Windows.Forms.TextBox textBoxDay;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.TextBox textBoxUpdateTime;
        private System.Windows.Forms.Panel panelBackgorund;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Label labelBackgound;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panelLogFite;
        private System.Windows.Forms.Button buttonLogFile;
        private System.Windows.Forms.TextBox textBoxLogFile;
        private System.Windows.Forms.Label labelLogFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}