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
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            //if (pilots.Any(p => p?.Name == name))
            //{
            //    return $"Pilot {name} is hired already";
            //}

            //IPilot pilot = new Pilot(name);
            //pilots.Add(pilot);
            //return $"Pilot {name} hired";

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
            //if (machines.Any(m => m.Name == name))
            //{
            //    return $"Machine {name} is manufactured already";
            //}

            //IMachine tank = new Tank(name, attackPoints, defensePoints);

            //machines.Add(tank);

            //return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";

            IMachine machine = machines.FirstOrDefault(m => m.Name == name);

            if (machine != null && machine is Tank)
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            machines.Add(tank);

            return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(f => f.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine fighter = new Fighter(name, attackPoints, defensePoints);

            machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";

            //IMachine machine = machines.FirstOrDefault(m => m.Name == name);

            //if (machine != null && machine is Fighter)
            //{
            //    return $"Machine {name} is manufactured already";
            //}

            //IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            //machines.Add(fighter);

            //string aggresiveMode = fighter.AggressiveMode ? "ON" : "OFF";

            //return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: {aggresiveMode}";
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

            //foreach (var currPilot in pilots)
            //{
            //    string currentReport = currPilot.Report();

            //    if (currentReport.Contains(selectedMachineName))
            //    {
            //        return $"Machine {selectedMachineName} is already occupied";
            //    }
            //}

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

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

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {deffendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = pilots.FirstOrDefault(p => p.Name == pilotReporting);

            //if (pilot == null)
            //{
            //    return $"Pilot {pilotReporting} could not be found";
            //}

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = machines.FirstOrDefault(m => m.Name == machineName);

            //if (machine == null)
            //{
            //    return $"Machine {machineName} could not be found";
            //}

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IMachine machine = machines
                .FirstOrDefault(m => m.Name == fighterName);

            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            IFighter fighter = (IFighter)machine;

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";

            //foreach (var machine  in machines)
            //{
            //    if (machine is Fighter && machine.Name == fighterName)
            //    {
            //        IFighter fighter = (Fighter)machines.FirstOrDefault(m => m.Name == fighterName);
            //        fighter.ToggleAggressiveMode();

            //        return $"Fighter {fighterName} toggled aggressive mode";
            //    }
            //}

            //return $"Machine {fighterName} could not be found";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            //IMachine machine = machines
            //    .FirstOrDefault(t => t.Name == tankName);

            //if (machine == null)
            //{
            //    return $"Machine {tankName} could not be found";
            //}

            //ITank tank = (ITank)machine;

            //tank.ToggleDefenseMode();

            //return $"Tank {tankName} toggled defense mode";

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