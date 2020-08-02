using NUnit.Framework;
using System;
using System.Reflection;

[TestFixture]
public class DummyTests
{
    private Dummy target;
    private Dummy deadTarget;
    private const int attackPoints = 10;
    private const int health = 20;
    private const int experience = 20;
    private const int dead = -1;
    [SetUp]
    public void Initialize()
    {
        target = new Dummy(health, experience);
        deadTarget = new Dummy(dead, experience);
    }
    [Test]
    public void LoosesHealthIfAttacked()
    {
        Dummy target = new Dummy(health, experience);
        target.TakeAttack(attackPoints);
        Assert.That(target.Health, Is.EqualTo(10), "Dummy does not loose health on attack");
    }
    [Test]
    public void DeadDummyAttacked()
    {

        Assert.That(() => deadTarget.TakeAttack(attackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."),
            "Dead dummy can be attacked");
    }

    [Test]
    public void CanGiveXp()
    {
        int experience = 0;
        experience = deadTarget.GiveExperience();

        Assert.That(experience, Is.EqualTo(experience));

    }

    [Test]
    public void CanNotGiveXP()
    {
        Assert.That(() => target.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
