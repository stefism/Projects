using System;

namespace _08_MillitaryElite_Daskal
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, 
            string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string currentCorps)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(currentCorps, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps}";
        }
    }
}
