using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brightness_Indicator
{
    class Volume
    {
        private static MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        private static MMDevice device = DevEnum.GetDefaultAudioEndpoint((DataFlow)0, (Role)1);
        public static int GetVolume()
        {
            int result = 100;
            try
            {
                
              
                result = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                
            }
            catch (Exception)
            {
            }

            return result;
        }

        public static bool GetMute()
        {
            bool result = false;
            try
            {
               // MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
                //MMDevice device = DevEnum.GetDefaultAudioEndpoint((DataFlow)0, (Role)1);
                result = device.AudioEndpointVolume.Mute;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
