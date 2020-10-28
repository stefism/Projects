using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public class Mission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public string State { get; private set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
