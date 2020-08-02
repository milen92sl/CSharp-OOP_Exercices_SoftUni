using Moq;
using NUnit.Framework;
using Skeleton;
//using Skeleton.Tests;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsXpWhenTargetDies()
    {
        Mock<IWeapon> mockedWeapon = new Mock<IWeapon>();
        Mock<ITarget> mockedTarget = new Mock<ITarget>();

        mockedTarget.Setup(p => p.Health).Returns(10);
        mockedTarget.Setup(p => p.IsDead()).Returns(true);
        mockedTarget.Setup(p => p.GiveExperience()).Returns(10);
        //IWeapon weapon = mockedWeapon.Object;
        //ITarget target = mockedTarget.Object;

        Hero hero = new Hero("Pesho", mockedWeapon.Object);

        hero.Attack(mockedTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(10),
            "Hero does not gain XP when target dies");
    }
}