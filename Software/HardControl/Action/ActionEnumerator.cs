using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HardControl.Action
{
    public class ActionEnumerator
    {
        public static List<string> GetActions()
        {
            return Assembly
                .GetAssembly(typeof(IActionProvider))
                .GetTypes()
                .Where(x => x.BaseType == typeof(IActionProvider))
                .Select(x => x.Name)
                .ToList<string>();
        }

        public static IActionProvider CreateAction(string name)
        {
            var type = Assembly
                .GetAssembly(typeof(IActionProvider))
                .GetTypes()
                .Where(x => x.Name == name)
                .First();
            return Activator.CreateInstance(type) as IActionProvider;
        }

    }
}
