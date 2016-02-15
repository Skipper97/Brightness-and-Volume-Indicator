using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brightness_Indicator
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{brightness-indicator-mutex}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                mutex.ReleaseMutex();
            }
            else
            {
                Marox.Alert.Error("Another instance is already running!");
            }
        }
    }
}
