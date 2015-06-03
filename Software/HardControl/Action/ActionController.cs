using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardControl.Action
{
    class ActionController
    {
        public static readonly ActionController Instance = new ActionController();

        public Dictionary<byte, IActionProvider> Actions { get; private set; }

        private ActionController()
        {
            Actions = new Dictionary<byte, IActionProvider>();
            Actions.Add(0x01, null);
        }


        public void Invoke(byte p)
        {
            if (Actions.ContainsKey(p))
                if(Actions[p] != null)
                    Actions[p].Invoke();
        }
    }
}
