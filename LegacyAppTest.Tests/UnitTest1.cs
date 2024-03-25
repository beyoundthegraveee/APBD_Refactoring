using LegacyApp;

namespace LegacyAppTest.Tests;

public class UnitTest1
{
    [Fact]
    public void PositiveCase()
    {   
        

    }

    [Fact]
    public void NegativeCase()
    {
        var userService = new UserService();
        var addResult1 = userService.AddUser("Joe", "", "johndoemail.com", DateTime.Parse("1982-03-21"), 1);
        var addResult2 = userService.AddUser("Joe", "", "joemailcom", DateTime.Parse("1982-03-21"), 1);
        var addResult3 = userService.AddUser("Joe", "", "", DateTime.Parse("1982-03-21"), 1);
        var addResult4 = userService.AddUser("", "", "johndoemail.com", DateTime.Parse("1982-03-21"), 1);
        
        Console.WriteLine(addResult1.ToString());
        


    }
}