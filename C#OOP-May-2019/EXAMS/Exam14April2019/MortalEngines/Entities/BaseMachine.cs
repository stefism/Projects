using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, 
            double defensePoints, double healthPoints = 0)
        {
            Name = name;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            HealthPoints = healthPoints;
        }

        public string Name 
        {
            get => name;

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                name = value;
            }
        }

        public IPilot Pilot 
        {
            get => pilot;

            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                pilot = value;
            }
        }
        public double HealthPoints  { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double decreaseHealth = AttackPoints - DefensePoints;

            target.HealthPoints -= decreaseHealth;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Health: {HealthPoints}");
            sb.AppendLine($" *Attack: {AttackPoints}");
            sb.AppendLine($" *Defense: {DefensePoints}");
            sb.Append($" *Targets: ");

            if (Targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine(string.Join(",", Targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
