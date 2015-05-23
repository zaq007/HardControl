using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Info
{
    class TextInfo : IInfoProvider
    {
        public string Text { get; set; }

        public TextInfo()
        {
            Text = "";
        }

        public override string GetInfo()
        {
            return Text;
        }
    }
}
