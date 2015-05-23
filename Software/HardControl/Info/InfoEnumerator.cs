using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace HardControl.Info
{
    class InfoEnumerator
    {
        public static List<string> GetInfos()
        {
            return Assembly
                .GetAssembly(typeof(IInfoProvider))
                .GetTypes()
                .Where(x => x.BaseType == typeof(IInfoProvider))
                .Select(x => x.Name)
                .ToList<string>();
        }

        public static IInfoProvider CreateInfo(string name)
        {
            var type = Assembly
                .GetAssembly(typeof(IInfoProvider))
                .GetTypes()
                .Where(x=>x.Name == name)
                .First();
            return Activator.CreateInstance(type) as IInfoProvider;
                
        }

        public static void MakeMenu(ContextMenuStrip menu)
        {
            var infos = GetInfos();
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            foreach (var info in infos)
                items.Add(new ToolStripMenuItem(info, null, InfoEnumerator.SelectInfo));
            menu.Items.Add(new ToolStripMenuItem("Add", null, items.ToArray()));
        }

        private static void SelectInfo(object sender, EventArgs e)
        {
            InfoController.Instance.Infos.Add(CreateInfo(sender.ToString()));
            InfoController.Instance.UpdateInfosList();
        }
    }

}
