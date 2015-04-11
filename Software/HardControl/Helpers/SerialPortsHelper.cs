using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HardControl.Helpers
{
    class SerialPortsHelper
    {
        public static void UpdateSerialList(ComboBox box)
        {
            
            box.Items.Clear();
            box.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (box.Items.Count == 1)
                box.SelectedIndex = 0;
        }

    }
}
