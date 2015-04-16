using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Arduino
{
    class ArduinoConstants
    {
        public const int READY_FOR_CONNECTION = 'A';
        public const byte MSG_OK = 0x01;
        public const char MSG_INFO = '\x02';
        public const char MSG_END = '\x00';
    }


}
