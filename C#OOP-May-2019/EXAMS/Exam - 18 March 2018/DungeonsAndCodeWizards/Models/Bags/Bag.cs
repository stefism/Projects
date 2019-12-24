using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag : IBag
    {
        private List<IItem> items;
        public int Capacity { get; protected set; }

        public double Load => items.Select(i => i.Weight).Sum();

        public IReadOnlyCollection<IItem> Items
            => items.AsReadOnly();

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            if (item.Weight + Load > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public IItem GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: Bag is empty!");
            }

            IItem item = items.FirstOrDefault(i => i.GetType().Name == name);  // TODO Да не върне нул?
            
            if (item == null)
            {
                throw new ArgumentException($"Invalid Operation: No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }
}
