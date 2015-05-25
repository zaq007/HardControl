using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Info
{
    [Serializable]
    class TimeInfo : IInfoProvider
    {
        public override string GetInfo()
        {
            string info = DateTime.UtcNow.ToLocalTime().ToString("hh:mm:ss");
            if(info.Length > Width)
                return info.Substring(0, Width);
            return info;
        }
    }
}
