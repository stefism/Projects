namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        private MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(p => p?.Name == name) == false)
            {
                IPilot pilot = new Pilot(name);
                pilots.Add(pilot);
                return $"Pilot {name} hired";
            }

            return $"Pilot {name} is hired already";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            IMachine machine = machines.FirstOrDefault(m => m.Name == name);

            if (machine != null && machine is Tank)
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            machines.Add(tank);

            return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine machine = machines.FirstOrDefault(m => m.Name == name);

            if (machine != null && machine is Fighter)
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(fighter);

           
            return $"Fighter {name} manufactured - attack: {attackPoints}; defense: {defensePoints}; aggressive: {fighter.AggressiveMode}";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            IMachine machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            string pilotMachines = pilot.Report();

            if (pilotMachines.Contains(selectedMachineName))
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine deffendingMachine = machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (deffendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (deffendingMachine.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackingMachine.Attack(deffendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {deffendingMachine.HealthPoints}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = machines.FirstOrDefault(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            foreach (var machine  in machines)
            {
                if (machine is Fighter && machine.Name == fighterName)
                {
                    IFighter fighter = (Fighter)machines.FirstOrDefault(m => m.Name == fighterName);
                    fighter.ToggleAggressiveMode();

                    return $"Fighter {fighterName} toggled aggressive mode";
                }
            }

            return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            foreach (var machine in machines)
            {
                if (machine is Tank && machine.Name == tankName)
                {
                    ITank tank = (Tank)machines.FirstOrDefault(t => t.Name == tankName);
                    tank.ToggleDefenseMode();

                    return $"Tank {tankName} toggled defense mode";
                }
            }

            return $"Machine {tankName} could not be found";
        }
    }
}