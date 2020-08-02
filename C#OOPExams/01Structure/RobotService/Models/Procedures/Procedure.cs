namespace RobotService.Models.Procedures
{
using System;
using System.Collections;
using System.Text;
using RobotService.Utilities.Messages;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System.Collections.Generic;

public abstract class Procedure : IProcedure
{
    protected ICollection<IRobot> robots;

    protected Procedure()
    {
        this.robots = new HashSet<IRobot>();
    }
    public string History()
    {
        var result = new StringBuilder();

        result.AppendLine(this.GetType().Name);

        foreach (var robot in this.robots)
        {
            result.AppendLine($"{robot.ToString()}");
        }

        return result.ToString().TrimEnd();
    }
    public virtual void DoService(IRobot robot, int procedureTime)
    {
        if (robot.ProcedureTime < procedureTime)
        {
            throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
        }

        robot.ProcedureTime -= procedureTime;

    }
}
}