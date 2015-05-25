using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Info
{
    [Serializable]
    abstract class IInfoProvider
    {
        const int MAX_WIDTH = 20;

        protected int Width { get { return MAX_WIDTH - X; } }

        public int X { get; set; }
        public int Y { get; set; }

        public abstract string GetInfo();
    }
}
