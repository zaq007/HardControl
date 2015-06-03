using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Action
{
    [Serializable]
    public abstract class IActionProvider
    {
        public abstract void Invoke();
    }
}
