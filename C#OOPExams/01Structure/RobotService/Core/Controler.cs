namespace RobotService.Core
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Procedures;
    using RobotService.Models.Robots;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    using RobotService.Core.Contracts;
    using RobotService.Models.Garages;
    using RobotService.Models.Garages.Contracts;

    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure charge;
        private IProcedure chip;
        private IProcedure polish;
        private IProcedure rest;
        private IProcedure techCheck;
        private IProcedure work;

        public Controller()
        {
            this.garage = new Garage();
            this.charge = new Charge();
            this.chip = new Chip();
            this.polish = new Polish();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();

        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                var exMsg = String.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(exMsg);
            }

            this.garage.Manufacture(robot);
            var result = String.Format(OutputMessages.RobotManufactured, name);
            return result;
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.chip.DoService(robot, procedureTime);

            var result = String.Format(OutputMessages.ChipProcedure, robotName);
            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.techCheck.DoService(robot, procedureTime);

            var result = String.Format(OutputMessages.TechCheckProcedure, robotName);
            return result;
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.rest.DoService(robot, procedureTime);

            var result = String.Format(OutputMessages.RestProcedure, robotName);
            return result;
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.work.DoService(robot, procedureTime);

            var result = String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return result;
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.charge.DoService(robot, procedureTime);

            var result = String.Format(OutputMessages.ChargeProcedure, robotName);
            return result;
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.polish.DoService(robot, procedureTime);

            var result = String.Format(OutputMessages.PolishProcedure, robotName);
            return result;
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckAreRobotIsExist(robotName);
            var robot = GetRobotByItsName(robotName);

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                var sellMsg = String.Format(OutputMessages.SellChippedRobot, ownerName);
                return sellMsg;
            }
            else
            {
                var sellMsg = String.Format(OutputMessages.SellNotChippedRobot, ownerName);
                return sellMsg;
            }
        }

        public string History(string procedureType)
        {
            string result = string.Empty;

            if (procedureType == nameof(Charge))
            {
                result = this.charge.History();
            }
            else if (procedureType == nameof(Chip))
            {
                result = this.chip.History();
            }
            else if (procedureType == nameof(Polish))
            {
                result = this.polish.History();
            }
            else if (procedureType == nameof(Rest))
            {
                result = this.rest.History();
            }
            else if (procedureType == nameof(TechCheck))
            {
                result = this.techCheck.History();
            }
            else if (procedureType == nameof(Work))
            {
                result = this.work.History();
            }

            return result;
        }

        private void CheckAreRobotIsExist(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }
        }

        private IRobot GetRobotByItsName(string robotName)
        {
            return this.garage.Robots.GetValueOrDefault(robotName);
        }

    }
}