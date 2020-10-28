using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters.Contracts
{
    public interface IAttackable
    {
        void Attack(ICharacter character);
    }
}
