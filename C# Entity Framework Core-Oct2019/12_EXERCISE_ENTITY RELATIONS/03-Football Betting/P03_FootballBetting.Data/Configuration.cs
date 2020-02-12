using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    internal static class Configuration
    {
        internal const string DefaultConnection =
            @"Server=STEFCHO\SQLEXPRESS;
                Database=FootballBetting;
                Integrated Security=True;";
    }
}
