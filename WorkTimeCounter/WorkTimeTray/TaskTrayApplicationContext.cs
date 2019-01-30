using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using WorkTimeCounter;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WorkTimeTray
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon = new NotifyIcon();
        private Configuration configWindow = new Configuration();
        private Settings settings = new Settings();
        private PopupTray popupTray = new PopupTray();

        private Timer _timer;
        private Timer timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new Timer(minute * 60 * 1000);
                    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                }

                return _timer;
            }
        }

        private double minute;
        private double hours;
        private UpTime up;

        public Font _fontToUse;
        private Color colorBlack;
        private PrivateFontCollection pfc = new PrivateFontCollection();
        public Font fontToUse
        {
            get
            {
                if (_fontToUse == null)
                {
                    try
                    {
                        int fontLength = Properties.Resources.Attentica_4F_UltraLight.Length;
                        byte[] fontdata = Properties.Resources.Attentica_4F_UltraLight;
                        IntPtr data = Marshal.AllocCoTaskMem(fontLength);
                        Marshal.Copy(fontdata, 0, data, fontLength);
                        pfc.AddMemoryFont(data, fontLength);
                        _fontToUse = new Font(pfc.Families[0]/*"Rockwell Condensed"*/, 14, FontStyle.Regular, GraphicsUnit.Pixel);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Font Error: " + ex.Message + "\nin string " + Regex.Match(ex.StackTrace.ToString(), @"\d+$").Value);
                        Environment.Exit(0);
                    }
                }
                return _fontToUse;
            }
        }

        private void LoadSettings()
        {
            minute = Properties.Settings.Default.UpdateTime;
            hours = Properties.Settings.Default.DayLength;
            colorBlack = Properties.Settings.Default.BackgroundColor;
        }

        public TaskTrayApplicationContext()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Exit);
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem settingsMenuItem = new MenuItem("Settings", new EventHandler(ShowSettings));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            up = new UpTime();
            notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenu = new ContextMenu(
                new MenuItem[] {
                    configMenuItem,
                    settingsMenuItem,
                    exitMenuItem });
            notifyIcon.Visible = true;
            LoadSettings();
            timer_Elapsed();
        }


        private void timer_Elapsed(object sender = null, ElapsedEventArgs e = null)
        {
            try
            {
                timer.Stop();
                TimeSpan ts = up.getUpTime();
                //ts = new TimeSpan(3,40,0);
                double h = ts.TotalHours;
                string time = ((int)h).ToString() + ":" + ts.Minutes.ToString("00");
                double progress = h / hours;
                if (progress > 1)
                {
                    progress = 1;
                }
                byte r = (byte)(128 + (255 * progress) / 2);//128 - 255
                byte g = (byte)(255 - 255 * progress);//255-0
                Color col = Color.FromArgb(r, g, 0);

                notifyIcon.Icon = CreateTextIcon(time, col, progress);
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Timer Error: " + ex.Message + "\nin string " + Regex.Match(ex.StackTrace.ToString(), @"\d+$").Value);
                Environment.Exit(0);
            }
        }
        public Icon CreateTextIcon(string str,Color foreground,double progress)
        {
            Icon result = null;
            try
            {
                Bitmap bitmapText = new Bitmap(16, 16);
                Graphics grphc = Graphics.FromImage(bitmapText);
                grphc.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

                grphc.Clear(colorBlack);

                Brush brushToUse = new SolidBrush(foreground);
                grphc.DrawString(str, fontToUse, brushToUse, -2, -2);
                Rectangle r = new Rectangle(0, 16 - 3, (int)(16 * progress), 3);
                grphc.FillRectangle(brushToUse, r);
                result = Icon.FromHandle(bitmapText.GetHicon());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Icon Error: " + ex.Message + "\nin string " + Regex.Match(ex.StackTrace.ToString(),@"\d+$").Value);
                Environment.Exit(0);
            }
            return result;
        }

        private void ShowPopupTray(object sender = null, EventArgs e = null)
        {
            if (popupTray.Visible)
                popupTray.Focus();
            else
            {
                Label tb = new Label();
                tb.Text = "Message";
                popupTray.ShowDialog(tb);
            }
        }
        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }
        void ShowSettings(object sender, EventArgs e)
        {
            DialogResult diRes = DialogResult.Cancel;
            if (settings.Visible)
                settings.Focus();
            else
                diRes = settings.ShowDialog();
            if (diRes != DialogResult.OK)
            {
                return;
            }
            LoadSettings();
        }

        void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }


        void ShowMessage(object sender, EventArgs e)
        {
            ShowPopupTray();
            // Only show the message if the settings say we can.
            //if (Properties.Settings.Default.ShowMessage)
            //    MessageBox.Show("Hello World");
        }
    }
}
