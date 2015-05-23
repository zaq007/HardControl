using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HardControl.Info
{
    class InfoController
    {
        public static InfoController Instance = new InfoController();

        public List<IInfoProvider> Infos { get; private set; }

        ComboBox box;

        InfoController() {
            Infos = new List<IInfoProvider>();
            Infos.Add(new TimeInfo());
        }

        public string GetInfo()
        {
            StringBuilder result = new StringBuilder(new String(' ', 60));
            foreach (var info in Infos)
            {
                var i = info.GetInfo();
                for (int j = 0; j < i.Count(); j++)
                    result[info.X * 20 + info.Y + j] = i[j];
            }
            return result.ToString();
        }

        public void UpdateInfosList(ComboBox list)
        {
            box = list;
            list.Items.Clear();
            foreach (var info in Infos)
                list.Items.Add(info);
        }

        public void UpdateInfosList()
        {
            UpdateInfosList(box);
        }
    }
}
