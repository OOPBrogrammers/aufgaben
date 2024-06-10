
using Blatt1A23;

namespace Blatt1A23Tests;

public class Tests
{
    
    [Test]
    public void TestPotenz()
    {
        if(!Program.Potenz(5, 0).Equals(1.0)) Assert.Fail();   
        if(!Program.Potenz(5, 1).Equals(5.0)) Assert.Fail();
        if(!Program.Potenz(5, 2).Equals(25.0)) Assert.Fail();
        if(!Program.Potenz(3.5, 1).Equals(3.5)) Assert.Fail();
    }

    [Test]
    public void TestPotenzRek()
    {
        if(!Program.PotenzRek(5, 0).Equals(1.0)) Assert.Fail();   
        if(!Program.PotenzRek(5, 1).Equals(5.0)) Assert.Fail();
        if(!Program.PotenzRek(5, 2).Equals(25.0)) Assert.Fail();
        if(!Program.PotenzRek(3.5, 1).Equals(3.5)) Assert.Fail();
    }
}