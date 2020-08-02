using System.Collections.Generic;

namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class TechCheck : Procedure
    {
        private const int DecreaseEnergy = 8;

        public TechCheck()
        {
            this.robots = new HashSet<IRobot>();
        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
                robot.Energy -= DecreaseEnergy;
            }

            robot.Energy -= DecreaseEnergy;
            this.robots.Add(robot);
        }
    }
}