using System;
using System.Windows.Forms;

namespace WorkTimeTray
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }
        private void LoadSettings(object sender, EventArgs e)
        {
            showMessageCheckBox.Checked = Properties.Settings.Default.ShowMessage;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.ShowMessage = showMessageCheckBox.Checked;
                Properties.Settings.Default.Save();
            }
        }
    }
}
