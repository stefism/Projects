using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    internal static class Connection
    {
        internal const string DefaultConnection =
            @"Server=DESKTOP-LNP1A21\SQLEXPRESS;
                Database=StudentSystem;
                Integrated Security=True;";
    }
}
