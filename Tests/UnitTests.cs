using Fagdag.FunctionApp;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Enkel test av kalkulator metoden

        int a = 12;
        int b = 5;
        int expected = 17;

        int sum = Kalkulator.Sum(a, b);

        Assert.That(Equals(expected, sum), $"Forventet sum: {expected}, men sum var: {sum}");
    }

    [Test]
    public void TestSomDetKanskjeErNoeGaltMed()
    {
        int a = 4;
        int b = 1;
        int expected = 5;

        int sum = Kalkulator.Sum(a, b);

        Assert.That(Equals(expected, sum), $"Forventet sum: {expected}, men sum var: {sum}");
    }
}