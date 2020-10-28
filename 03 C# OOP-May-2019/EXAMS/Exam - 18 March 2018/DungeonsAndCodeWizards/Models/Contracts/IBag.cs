using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IBag
    {
        int Capacity { get; }
        double Load { get; }
        IReadOnlyCollection<IItem> Items { get; }
        void AddItem(IItem item);
        IItem GetItem(string name);
    }
}
