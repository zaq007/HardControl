using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace HardControl.Arduino
{
    class Arduino : IDisposable
    {
        static Arduino Instance;

        public SerialPort Port { get; private set; }

        private Arduino(SerialPort port)
        {

        }

        public static Arduino GetInstance()
        {
            return Instance;
        }

        public static Arduino SetInstance(SerialPort port)
        {
            Instance = getInstance(port);
            if (Instance != null)
                port.WriteLine("OK");    
            return Instance;
        }


        private static Arduino getInstance(SerialPort port)
        {
            port.Open();
            if (port.ReadByte() == ArduinoConstants.READY_FOR_CONNECTION)
                return new Arduino(port);
            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
