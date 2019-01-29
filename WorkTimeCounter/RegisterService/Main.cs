using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.ServiceProcess;
using System.IO;

namespace RegisterService
{
    public partial class Main : Form
    {
        private Timer timer;
        private ServiceController ctl;
        private bool _isInstall;
        private bool isInstall
        {
            get
            {
                return _isInstall;
            }
            set
            {
                _isInstall = value;
                if (value)
                {
                    serviceName = ctl.ServiceName;
                    Run(() => {
                        labelLogInfo.ForeColor = Color.DarkKhaki;
                        buttonInstall.Enabled = false;
                        buttonUnInstall.Enabled = !isRun;
                    });
                    
                }
                else
                {
                    isRun = false;
                    Run(() => {
                        labelLogInfo.ForeColor = Color.Red;
                        buttonInstall.Enabled = File.Exists(fileName);
                        buttonUnInstall.Enabled = false;
                    });
                }
            }
        }
        private bool _isRun;
        private bool isRun
        {
            get
            {
                return _isRun;
            }
            set
            {
                _isRun = value;
                if (value)
                {
                    isInstall = true;
                    serviceName = ctl.ServiceName;
                    Run(() => {
                        labelLogInfo.ForeColor = Color.Green;
                        buttonRun.Enabled = false;
                        buttonStop.Enabled = true;
                    });
                }
                else
                {
                    Run(() => {
                        labelLogInfo.ForeColor = Color.DarkKhaki;
                        buttonRun.Enabled = isInstall;
                        buttonStop.Enabled = false;
                    });
                }
            }
        }

        public string serviceName
        {
            get
            {
             return textBoxServiceName.Text;
            }
            set
            {
                textBoxServiceName.Text = value;
                Properties.Settings.Default.serviceName = value;
                Properties.Settings.Default.Save();
            }
        }

        public string _fileName;
        public string fileName
        {
            get
            {
                if (!File.Exists(_fileName))
                {
                    fileName = "";
                }
                return _fileName;
            }
            private set
            {
                _fileName = value;
                Properties.Settings.Default.servicePath = value;
                Properties.Settings.Default.Save();
            }
        }

        public Main()
        {
            InitializeComponent();
            serviceName = Properties.Settings.Default.serviceName;
            fileName = Properties.Settings.Default.servicePath;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        private void Run(Action act)
        {
            try
            {

                this.Invoke(new MethodInvoker(delegate () {
                    if (act != null)
                    {
                        act();
                    }
                }));
            }
            catch{}
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                Run(() => {
                    isInstall = false;
                    labelLogInfo.Text = "Пустое имя службы";
                });
                return;
            }
            try
            {
                var listServ = ServiceController.GetServices();
                ctl = listServ.FirstOrDefault(s => s.ServiceName.ToLower() == textBoxServiceName.Text.ToLower());
            }
            catch (Exception ex)
            {
                Run(() => {
                    isInstall = false;
                    labelLogInfo.Text = "Ошибка поиска службы " + ex.Message;
                });
            }
            if (ctl == null)
            {
                Run(() => {
                    isInstall = false;
                    labelLogInfo.Text = "Служба не найдена";
                });
                return;
            }
            else
            {
                if (ctl.Status != ServiceControllerStatus.Running)
                {
                    Run(() => {
                        isInstall = true;
                        isRun = false;
                        labelLogInfo.Text = "Служба установлена статус " + ctl.Status;
                    });
                }
                else
                {
                    Run(() => {
                        isRun = true;
                        labelLogInfo.Text = "Служба запущена";
                    });
                }

            }
        }

        private void textBoxServiceName_TextChanged(object sender, EventArgs e)
        {
            serviceName = textBoxServiceName.Text;
        }

        private void Browse_click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel || !File.Exists(fileName = openFileDialog1.FileName))
            {
                return;
            }
            textBoxFileName.Text = fileName;
            serviceName = Path.GetFileNameWithoutExtension(fileName);
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (!File.Exists(fileName))
            {
                return;
            }
            if (!isInstall)
            {
                //Installs and starts the service
                ServiceManager.InstallAndStart(serviceName, serviceName, fileName);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (!isInstall)
            {
                return;
            }
            ServiceManager.StartService(serviceName);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (!isInstall)
            {
                return;
            }
            ServiceManager.StopService(serviceName);
        }

        private void buttonUnInstall_Click(object sender, EventArgs e)
        {
            if (isInstall)
            {
                ServiceManager.Uninstall(serviceName);
            }
        }
    }
}
