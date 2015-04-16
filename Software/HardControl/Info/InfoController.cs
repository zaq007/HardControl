using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Info
{
    class InfoController
    {
        Dictionary<string, IInfoProvider> infos;

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var info in infos)
                sb.Append(info.Value);
            return sb.ToString();
        }
    }
}
