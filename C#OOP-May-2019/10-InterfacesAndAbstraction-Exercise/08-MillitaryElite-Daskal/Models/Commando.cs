using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(string id, string firstName, 
            string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => missions;

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString().TrimEnd()}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
