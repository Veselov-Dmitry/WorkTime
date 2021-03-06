﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WorkTimeTray
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            ReadPropertiesSettings();
        }

        private void ReadPropertiesSettings()
        {
            textBoxUpdateTime.Text = Properties.Settings.Default.UpdateTime.ToString();
            textBoxDay.Text = Properties.Settings.Default.DayLength.ToString();
            panelColor.BackColor = Properties.Settings.Default.BackgroundColor;
            textBoxLogFile.Text = Properties.Settings.Default.LogFile;
        }

        private void VerText(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
            {
                return;
            }
            var text = tb.Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d+([,|.|]\d+)*$"))
            {
                errorProviderNumber.SetError(tb, "");
            }
            else
            {
                errorProviderNumber.SetError(tb, "Digits only");
            }
            //errorProviderNumber
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UpdateTime = ParceToDpuble(textBoxUpdateTime.Text, 0.5);
            Properties.Settings.Default.DayLength = ParceToDpuble(textBoxDay.Text, 4);
            Properties.Settings.Default.BackgroundColor = panelColor.BackColor;
            string logPath = textBoxLogFile.Text;
            if (File.Exists(logPath))
            {
                Properties.Settings.Default.LogFile = logPath;
            }
            else
            {
                MessageBox.Show("file ["+ logPath + "] does not exists", "NotFound",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private double ParceToDpuble(string text, double defaultVal)
        {
            double val = 0;
            Double.TryParse(text, out val);
            return (val == 0) ? defaultVal : val;
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = panelColor.BackColor;
            var dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                panelColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonLogFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (openFileDialog1.FileName.Length > 255)
                {
                    MessageBox.Show("file path is longer than 255 characters", "Length of the path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxLogFile.Text = Properties.Settings.Default.LogFile;
                    return;
                }
                textBoxLogFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
