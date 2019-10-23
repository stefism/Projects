using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;

            ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            State = State.Finished;
        }

        private void ParseState(string currState)
        {
            State state;

            bool parsed = Enum.TryParse<State>(currState, out state);

            if (!parsed)
            {
                throw new InvalidStateException();
            }

            State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
