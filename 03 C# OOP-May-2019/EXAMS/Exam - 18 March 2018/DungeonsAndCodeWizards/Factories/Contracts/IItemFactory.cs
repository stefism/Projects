using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories.Contracts
{
    public interface IItemFactory
    {
        IItem CreateItem(string type);
    }
}
