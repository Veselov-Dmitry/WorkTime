using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Timers;
using Timer = System.Timers.Timer;
using WorkTimeCounter;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WorkTimeService
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private UpTime up;
        private float minute = 0.1f;// every 10 minutes

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                up = new UpTime();
                _timer = new Timer(minute * 60 * 1000);
                _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                _timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("OnStart Error: " + ex.Message + "\nin string " + Regex.Match(ex.StackTrace.ToString(), @"\d+$").Value);
                Environment.Exit(0);
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // stop the timer while we are running the cleanup task
                _timer.Stop();
                IsProcessRunning("WorkTimeTray");
                up.WriteTimeLog();
                _timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Elapsed Error: " + ex.Message + "\nin string " + Regex.Match(ex.StackTrace.ToString(), @"\d+$").Value);
                Environment.Exit(0);
            }
        }
        private void IsProcessRunning(string sProcessName)
        {
            try
            {
                System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(sProcessName);
                if (proc.Length > 0)
                    return;
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + sProcessName;
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProcessRunning Error: " + ex.Message + "\nin string " + Regex.Match(ex.StackTrace.ToString(), @"\d+$").Value);
                Environment.Exit(0);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
