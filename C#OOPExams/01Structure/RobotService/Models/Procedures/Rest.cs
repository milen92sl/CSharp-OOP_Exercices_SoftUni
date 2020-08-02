using System.Collections.Generic;

namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Rest : Procedure
    {
        private const int DecreaseHappiness = 3;
        private const int IncreaseEnergy = 10;

        public Rest()
        {
            this.robots = new HashSet<IRobot>();
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= DecreaseHappiness;
            robot.Energy += IncreaseEnergy;
            this.robots.Add(robot);
        }
    }
}