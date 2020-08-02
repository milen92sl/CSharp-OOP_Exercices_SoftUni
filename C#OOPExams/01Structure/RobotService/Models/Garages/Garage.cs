using System.Linq;

namespace RobotService.Models.Garages
{
    using System;
    using RobotService.Models.Robots;
    using RobotService.Utilities.Messages;
    using System.Collections.Generic;
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Robots.Contracts;

    public class Garage : IGarage
    {
        private const int GarageCapacity = 10;
        private int capacity;
        private readonly Dictionary<string, IRobot> garageRobots;

        public Garage()
        {
            this.capacity = GarageCapacity;
            this.garageRobots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots
        {
            get => this.garageRobots;
        }
        public void Manufacture(IRobot robot)
        {
            if (Robots.Count == this.capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (Robots.ContainsKey(robot.Name))
            {
                var exMsg = String.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(exMsg);
            }
            this.garageRobots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.garageRobots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }

            var robot = this.Robots.GetValueOrDefault(robotName);
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.garageRobots.Remove(robotName);
        }
    }
}