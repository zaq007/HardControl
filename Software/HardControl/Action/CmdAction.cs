using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HardControl.Action
{
    [Serializable]
    public class CmdAction : IActionProvider
    {
        public string Cmd { get; set; }

        public override void Invoke()
        {
            Process.Start("cmd.exe", Cmd);
        }
    }
}
