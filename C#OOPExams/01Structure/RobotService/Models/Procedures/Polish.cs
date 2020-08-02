using System.Collections.Generic;

namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Polish : Procedure
    {
        private const int DecreaseHappiness = 7;

        public Polish()
        {
            this.robots = new HashSet<IRobot>();
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= DecreaseHappiness;
            this.robots.Add(robot);
        }
    }
}