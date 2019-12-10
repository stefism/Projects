using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Contracts
{
    public interface IItem
    {
        int Weight { get; }
        void AffectCharacter(ICharacter character);
    }
}
