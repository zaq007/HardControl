using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Helpers
{
    class ArduinoHelper
    {
        public static byte[] MakeInfo()
        {
            string info = ""; 
            info += Arduino.ArduinoConstants.MSG_INFO;
            info += "Time: ";
            info  += DateTime.UtcNow.ToString("hh:mm:ss");
            info += "\x00";
            return ASCIIEncoding.ASCII.GetBytes(info);
        }

    }
}
