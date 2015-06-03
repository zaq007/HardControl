using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HardControl.Action
{
    [Serializable]
    public class MessageAction : IActionProvider
    {
        public string Message { get; set; }

        public override void Invoke()
        {
            MessageBox.Show(Message);
        }
    }
}
