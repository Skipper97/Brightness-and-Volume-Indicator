using System;

namespace Brightness_Indicator
{
    public static class Brightness
    {
        //define scope (namespace)
        private static System.Management.ManagementScope s = new System.Management.ManagementScope("root\\WMI");

        //define query
        private static System.Management.SelectQuery q = new System.Management.SelectQuery("WmiMonitorBrightness");

        public static int GetBrightness()
        {
            byte curBrightness = 0;

            try
            {
                //output current brightness
                System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(s, q);
                System.Management.ManagementObjectCollection moc = mos.Get();

                //store result
                foreach (System.Management.ManagementObject o in moc)
                {
                    curBrightness = (byte)o.GetPropertyValue("CurrentBrightness");
                    break; //only work on the first object
                }

                moc.Dispose();
                mos.Dispose();
            }
            catch (Exception)
            {
            }

            return (int)curBrightness;
        }

        //array of valid brightness values in percent
        public static byte[] GetBrightnessLevels()
        {
            //define scope (namespace)
            System.Management.ManagementScope s = new System.Management.ManagementScope("root\\WMI");

            //define query
            System.Management.SelectQuery q = new System.Management.SelectQuery("WmiMonitorBrightness");

            //output current brightness
            System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(s, q);
            byte[] BrightnessLevels = new byte[0];

            try
            {
                System.Management.ManagementObjectCollection moc = mos.Get();

                //store result

                foreach (System.Management.ManagementObject o in moc)
                {
                    BrightnessLevels = (byte[])o.GetPropertyValue("Level");
                    break; //only work on the first object
                }

                moc.Dispose();
                mos.Dispose();
            }
            catch (Exception)
            {
                // MessageBox.Show("Sorry, Your System does not support this brightness control...");
            }

            return BrightnessLevels;
        }
    }
}