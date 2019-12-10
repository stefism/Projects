using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories.Contracts
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter(string type, string name, string faction);
    }
}
