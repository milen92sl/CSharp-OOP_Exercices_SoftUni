using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Dummy target;
    private int durability;
    private int attack;
    private Axe axe;
    [SetUp]
    public void Initialize()
    {
        target = new Dummy(5,5);
        durability = 2;
        attack = 2;
        axe = new Axe(attack, durability);
    }
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe.Attack(target);
        int expectedDurability = 1;

        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurability)
            ,"Axe does not loose durability.");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        axe.Attack(target);
        axe.Attack(target);
        Assert.That(() => axe.Attack(target),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."),
            "Broken weapon can attack");
    }
}