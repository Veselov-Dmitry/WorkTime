using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Timers;
using WorkTimeCounter;

namespace WorkTimeService
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private UpTime up;
        private float minute = 1f;// every 10 minutes

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            up = new UpTime();
            _timer = new Timer(minute * 60 * 1000); 
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // stop the timer while we are running the cleanup task
            _timer.Stop();
            IsProcessRunning("WorkTimeTray");
            up.WriteTimeLog();
            _timer.Start();
        }
        private void IsProcessRunning(string sProcessName)
        {
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(sProcessName);
            if (proc.Length > 0)
                return;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\"+ sProcessName;
            Process.Start(path);
        }

        protected override void OnStop()
        {
        }
    }
}
