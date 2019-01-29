using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using WorkTimeCounter;

namespace WorkTimeTray
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon = new NotifyIcon();
        private Configuration configWindow = new Configuration();
        private Timer _timer;
        private float minute = 0.5f;
        private UpTime up;

        public TaskTrayApplicationContext()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Exit);
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            up = new UpTime();
            notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
            _timer = new Timer(minute * 60 * 1000);
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer_Elapsed();
        }
        private void timer_Elapsed(object sender = null, ElapsedEventArgs e = null)
        {
            // stop the timer while we are running the cleanup task
            _timer.Stop();
            TimeSpan ts = up.getUpTime();
            //ts = new TimeSpan(3,40,0);
            double h = ts.TotalHours;
            string time = ((int)h).ToString() + ":" + ts.Minutes.ToString("00");
            double progress = h / 4;
            byte r = (byte)(128 + (255 * progress) /2);//128 - 255
            byte g = (byte)(255 - 255 * progress);//255-0

            Color col = Color.FromArgb(r, g, 0);
            notifyIcon.Icon = CreateTextIcon(time, col, progress);
            _timer.Start();
        }

        void ShowMessage(object sender, EventArgs e)
        {
            // Only show the message if the settings say we can.
            if (Properties.Settings.Default.ShowMessage)
                MessageBox.Show("Hello World");
        }

        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }
        public Icon CreateTextIcon(string str,Color foreground,double progress)
        {
            Font fontToUse = new Font("Rockwell Condensed", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush brushToUse = new SolidBrush(foreground);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(bitmapText);

            IntPtr hIcon;

            //g.Clear(Color.Transparent);
            g.Clear(Color.Black);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, fontToUse, brushToUse, -2, -2);
            Pen p = new Pen(foreground);
            Rectangle r = new Rectangle(0, 16-3, (int)(16 * progress), 3);
            g.FillRectangle(brushToUse, r);
            hIcon = (bitmapText.GetHicon());
            return Icon.FromHandle(hIcon);
            //DestroyIcon(hIcon.ToInt32);
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
