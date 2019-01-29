using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WorkTimeCounter
{
    class Program
    {
        static TimeSpan time;
        static UpTime up;
        static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
                up = new UpTime();
                while (true)
                {

                    time = up.WriteTimeLog();
                    DialogResult dr = MessageBox.Show("continue?","",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n"+ex.StackTrace.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
               // MessageBox.Show("Write time " + time.Hours + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00"),"OK");
            }
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs e)
        {
            return Assembly.Load(Properties.Resources.NewtonsoftJson);
        }
    }
}
