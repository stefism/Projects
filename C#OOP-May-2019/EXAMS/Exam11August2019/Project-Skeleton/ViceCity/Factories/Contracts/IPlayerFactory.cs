using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Factories.Contracts
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name);
    }
}
