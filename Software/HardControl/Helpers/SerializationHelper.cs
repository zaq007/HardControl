using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HardControl.Action;
using HardControl.Info;

namespace HardControl.Helpers
{
    [Serializable]
    class SerializationHelper
    {
        public List<IInfoProvider> Infos { get; set; }

        public Dictionary<byte, IActionProvider> Actions { get; set; }

    }
}
