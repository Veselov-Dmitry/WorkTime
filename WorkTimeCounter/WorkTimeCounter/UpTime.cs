//#define Message
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
#if Message
using System.Windows.Forms;
#endif
using Newtonsoft.Json;
using System.IO;
using System.Management;
using System.Reflection;

namespace WorkTimeCounter
{
    public class UpTime
    {
        public UpTime()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(delegate (object sender, ResolveEventArgs e)
            {
                return Assembly.Load(Properties.Resources.NewtonsoftJson);
            });
        }
        private string _pathLog;
        private string pathLog
        {
            get
            {
                if (string.IsNullOrEmpty(_pathLog))
                {
                    _pathLog = Properties.Settings.Default.pathLog;
                    if (string.IsNullOrEmpty(_pathLog))
                    {
                        _pathLog = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\log.json";
                        Properties.Settings.Default.pathLog = _pathLog;
                        Properties.Settings.Default.Save();
                    }
                }
                return _pathLog;
            }
        }

        public TimeSpan getUpTime()
        {
            var mo = new ManagementObject(@"\\.\root\cimv2:Win32_OperatingSystem=@");
            var lastBootUp = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());
            return DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();


            /*
            return new TimeSpan(0, 0, 0, Environment.TickCount);
            */

            /*PerformanceCounter pc = new PerformanceCounter("System", "System Up Time");
            pc.NextValue();
            int uptime = (int)pc.NextValue();
            return new TimeSpan(0, 0, uptime);*/

        }

        public string GetStr(object text)
        {
            return JsonConvert.SerializeObject(text);
        }
        public T GetObj<T>(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            T result = JsonConvert.DeserializeObject<T>(text);
            if (result == null)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            return result;
        }
        public TimeSpan WriteTime()
        {
            TimeSpan time = getUpTime();
            Properties.Settings.Default.Time = time;
            Properties.Settings.Default.Save();
            return time;
        }
        public TimeSpan ReadTime()
        {
            return Properties.Settings.Default.Time;
        }
        public string WriteJSON(string text)
        {
            Properties.Settings.Default.JSON = text;
            Properties.Settings.Default.Save();
            return text;
        }
        public string WriteJSON(object obj)
        {
            return WriteJSON(GetStr(obj));
        }
        public string ReadJSON()
        {
            return Properties.Settings.Default.JSON;
        }
        public T ReadJSON<T>()
        {
            return GetObj<T>(ReadJSON());
        }
        public void WriteFile(string text)
        {
            if (!File.Exists(pathLog))
            {
                File.Create(pathLog);
            }
            File.WriteAllText(pathLog, text, Encoding.UTF8);
        }
        public void WriteFile(object obj)
        {
            WriteFile(WriteJSON(obj));
        }
        public string ReadFile()
        {
            if (!File.Exists(pathLog))
            {
                File.Create(pathLog);
                return string.Empty;
            }
            var result = File.ReadAllText(pathLog);
            return result;
        }
        public T ReadFile<T>()
        {
            var result = GetObj<T>(ReadFile());
            return result;
        }
        public TimeSpan WriteTimeLog()
        {
#if Message
            var d1 = DateTime.Now;
#endif
            var time = getUpTime();
#if Message
            var str1 = "\ngetUpTime =" + (int)(DateTime.Now - d1).TotalMilliseconds;
            d1 = DateTime.Now;
#endif
            var list = ReadFile<List<Day>>();
            var now = DateTime.Now;
            var day = list.FirstOrDefault(x => x.Date.Date == now.Date);
            if (day == null)
            {
                list.Add(new Day() { Duration = time, Date = DateTime.Now });
            }
            else
            {
                int i = list.IndexOf(day);
                list[i].Duration = time;
            }
            WriteFile(list);
#if Message
            MessageBox.Show("WriteFile=" + (int)(DateTime.Now - d1).TotalMilliseconds+ str1, "OK");
#endif
            return time;
        }
    }
}
