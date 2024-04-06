using System.Runtime.InteropServices.JavaScript;
using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser("John", "Doe", "john", DateTime.Parse("1980-07-22"), 1);
        Assert.Equal(false, result);

    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Email_With_At_And_Dot()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser("John", "Doe", "john@gmail.com", DateTime.Parse("1980-07-22"), 1);
        Assert.Equal(true, result);

    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Name_Is_Null()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser("", "Doe", "john@gmail.com", DateTime.Parse("1980-07-22"), 1);
        Assert.Equal(false, result);

    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Date_Of_Birth_Is_Incorrect()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser("John", "Doe", "john@gmail.com", DateTime.Parse("2003-04-19"), 1);
        Assert.Equal(false, result);

    }

    
    [Fact]
    public void AddUser_Should_Return_True_When_Date_Of_Birth_Is_Correct()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser("John", "Doe", "john@gmail.com", DateTime.Parse("1980-07-22"), 1);
        Assert.Equal(true, result);

    }
    
    [Fact]
    public void Add_Very_Important_Client_Returns_True()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser(
            "Jan", 
            "Malewski", 
            "malewski@gmail.pl",
            DateTime.Parse("2000-01-01"),
            2
        );
        Assert.Equal(true, result);

    }
    
    [Fact]
    public void Add_Important_Client_Returns_True()
    {
        
        var sevice = new UserService();
        bool result = sevice.AddUser(
            "Jan", 
            "Smith", 
            "smith@gmail.pl",
            DateTime.Parse("2000-01-01"),
            3
        );
        Assert.Equal(true, result);

    }
    
    [Fact]
    public void Add_Normal_Client_Returns_False()
    {
        var sevice = new UserService();
        bool result = sevice.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@wp.pl",
            DateTime.Parse("2000-01-01"),
            1
        );
        Assert.Equal(false, result);

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    


}