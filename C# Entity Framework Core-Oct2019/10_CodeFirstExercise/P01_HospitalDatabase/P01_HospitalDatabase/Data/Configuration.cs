using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    internal static class Configuration
    {
        internal const string DefaultConnection = 
            @"Server=DESKTOP-LNP1A21\SQLEXPRESS;
                Database=HospitalDatabase;
                Integrated Security=True;";
    }
}
