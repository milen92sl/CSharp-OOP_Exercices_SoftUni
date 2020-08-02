namespace RobotService.Models.Procedures
{
    using System.Collections.Generic;
    using RobotService.Models.Robots.Contracts;

    public class Charge : Procedure
    {
        private const int IncreaseHappiness = 12;
        private const int IncreaseEnergy = 10;

        public Charge()
        {
            this.robots = new HashSet<IRobot>();
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += IncreaseHappiness;
            robot.Energy += IncreaseEnergy;
            this.robots.Add(robot);
        }
    }
}