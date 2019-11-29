using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
        hero = new Hero("Ivan", 23);
    }

    [Test]
    public void TestIfCreateHeroIsHull()
    {
        Hero hero1 = null;

        Assert.That(() => heroRepository.Create(hero1), 
            Throws.ArgumentNullException);
    }

    [Test]
    public void TestCreateHero()
    {
        string message = heroRepository.Create(hero);
        string exspectedMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(message, exspectedMessage);
    }

    [Test]
    public void TestIfHeroAlreadyExist()
    {
        heroRepository.Create(hero);

        Assert.That(() => heroRepository.Create(hero), 
            Throws.InvalidOperationException);
    }

    [Test]
    public void TestRemoveHero()
    {
        heroRepository.Create(hero);
        bool isRemove = heroRepository.Remove(hero.Name);
        
        Assert.IsTrue(isRemove);
    }

    [Test]
    public void TestRemoveHeroIfIsNull()
    {
        Assert.That(() => heroRepository.Remove(null), 
            Throws.ArgumentNullException);
    }

    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        Hero hero1 = new Hero("baba", 15);
        Hero hero2 = new Hero("lelka", 23);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Hero highHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(hero2, highHero);
    }

    [Test]
    public void TestGetHero()
    {
        Hero hero1 = new Hero("baba", 15);
        Hero hero2 = new Hero("lelka", 23);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Hero getHero = heroRepository.GetHero(hero2.Name);

        Assert.AreEqual(hero2, getHero);
    }

    [Test]
    public void TestGetCollection()
    {
        Hero hero1 = new Hero("baba", 15);
        Hero hero2 = new Hero("lelka", 23);

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Assert.That(() => heroRepository.Heroes.Count == 2);
    }
}