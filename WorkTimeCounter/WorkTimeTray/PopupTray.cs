using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkTimeTray
{
    public partial class PopupTray : Form
    {
        private Timer timer;
        private int startPosX;
        private int startPosY;

        public PopupTray()
        {
            InitializeComponent();
            // We want our window to be the top most
            TopMost = true;
            // Pop doesn't need to be shown in task bar
            ShowInTaskbar = false;
            // Create and run timer for animation
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += ShowAlpha;

            DoubleClick += buttonClose_Click;
            panelContent.DoubleClick += buttonClose_Click;
        }
        public DialogResult ShowDialog(Control content)
        {
            panelContent.Controls.Add(content);
            return ShowDialog();
        }

        double alpha = 0;
        private void ShowAlpha(object sender, EventArgs e)
        {
            alpha += 0.15;
            if (alpha >= 1)
            {
                Opacity = 1;
                timer.Stop();
                return;
            }
            Opacity = alpha;
        }


        protected override void OnLoad(EventArgs e)
        {
            // Move window out of screen
            startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
            //startPosY = Screen.PrimaryScreen.WorkingArea.Height;
            startPosY = Screen.PrimaryScreen.WorkingArea.Height - Height;
            SetDesktopLocation(startPosX, startPosY);
            BackColor = Color.Silver;
            Opacity = 0;
            base.OnLoad(e);
            // Begin animation
            timer.Start();
        }

        void ShowUp(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY -= 5;
            //If window is fully visible stop the timer
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
                timer.Stop();
            else
                SetDesktopLocation(startPosX, startPosY);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {            
            Opacity = alpha = 0;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
