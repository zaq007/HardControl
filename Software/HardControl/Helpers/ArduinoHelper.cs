using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HardControl.Info;

namespace HardControl.Helpers
{
    class ArduinoHelper
    {
        public static byte[] MakeInfo()
        {
            string info = ""; 
            info += Arduino.ArduinoConstants.MSG_INFO;
            info += InfoController.Instance.GetInfo();
            info += "\x00";
            return ASCIIEncoding.ASCII.GetBytes(info);
        }

    }
}
