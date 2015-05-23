using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using HardControl.Helpers;
using HardControl.Info;

namespace HardControl.Arduino
{
    class Arduino : IDisposable
    {
        static Arduino Instance;
        object locker = new object();

        public SerialPort Port { get; private set; }

        private Arduino(SerialPort port)
        {
            Port = port;
        }

        public static Arduino GetInstance()
        {
            return Instance;
        }

        public static Arduino SetInstance(SerialPort port)
        {
            Instance = getInstance(port);
            if (Instance != null)
                new Thread(Instance.WriteInfo).Start();   
            return Instance;
        }


        private static Arduino getInstance(SerialPort port)
        {
            port.Open();
            if (port.ReadByte() == ArduinoConstants.READY_FOR_CONNECTION)
                return new Arduino(port);
            return null;
        }

        public void Write(byte[] bytes)
        {
            lock (locker)
            {
                try
                {
                    this.Port.Write(bytes, 0, bytes.Count());
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public void WriteInfo()
        {
            byte[] last = ArduinoHelper.MakeInfo();
            this.Write(last);
            while (true)
            {
                byte[] info = ArduinoHelper.MakeInfo();
                if (ASCIIEncoding.ASCII.GetString(last).CompareTo(ASCIIEncoding.ASCII.GetString(info)) != 0)
                {
                    try
                    {
                        this.Write(info);
                    }
                    catch
                    {
                        Instance = null;
                        return;
                    }
                    last = info;
                    Lcd.Instance.Update();
                }
                Thread.Sleep(200);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
