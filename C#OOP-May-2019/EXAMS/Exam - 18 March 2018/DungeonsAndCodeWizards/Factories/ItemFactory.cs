using DungeonsAndCodeWizards.Factories.Contracts;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            Type itemType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(i => i.Name == type);

            if (itemType == null)
            {
                throw new ArgumentException($"Invalid item \"{type}\"!");
            }

            return (IItem)Activator.CreateInstance(itemType);
        }
    }
}
