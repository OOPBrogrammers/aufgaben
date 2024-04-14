using Blatt1A8;

namespace Blatt1A8Tests;

public class Tests
{
    [Test]
    public void TestKuerzen()
    {
        Bruch b = new Bruch(4, 10);
        b.Kuerze();
        if(b.VergleicheMit(new Bruch(2, 5)) != 0) Assert.Fail(b.ToString());
        Assert.Pass(b.ToString());
    }

    [Test]
    public void TestAddieren()
    {
        Bruch b = new Bruch(4, 10);
        b.Addiere(new Bruch(1, 3));
        if(b.VergleicheMit(new Bruch(22, 30)) != 0) Assert.Fail(b.ToString());
        Assert.Pass(b.ToString());
    }

    [Test]
    public void TestVergleichen()
    {
        Bruch b = new Bruch(1, 3);
        Bruch b2 = new Bruch(0, 3);
        Bruch b3 = new Bruch(3, 4);
        if(b.VergleicheMit(new Bruch(2, 6)) != 0) Assert.Fail();
        if(b.VergleicheMit(b) != 0) Assert.Fail(b.ToString());
        if(b.VergleicheMit(b2) != 1) Assert.Fail(b2.ToString());
        if(b.VergleicheMit(b3) != -1) Assert.Fail(b3.ToString());
        Assert.Pass();
    }
}