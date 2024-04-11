using System;
using LegacyApp;
using NUnit.Framework;

namespace LegacyApp.Tests;

[TestFixture]
public class UserServiceTest
{
    [Test]
    public void Dummy_Should_Return_True()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[1];
        // Act
        bool result = service.AddUser("test", "Malewski", "test@wp.pl", new DateTime(1995, 12, 1), 2);
        // Assert
        Assert.That(result == true);
    }
    
    [Test]
    public void User_Service_Add_Service_Should_Return_False_For_Client_1()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[1];
        // Act
        bool result = service.AddUser("test", client.Name, client.Email, new DateTime(1995, 12, 1), client.ClientId);
        // Assert
        Assert.That(result == false);
    }

    [Test]
    public void User_Service_Add_Service_Should_Return_True_For_Client_2()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[2];
        // Act
        bool result = service.AddUser("test", client.Name, client.Email, new DateTime(1995, 12, 1), client.ClientId);
        // Assert
        Assert.That(result == true);
    }

    [Test]
    public void User_Service_Add_Service_Should_Return_True_For_Client_3()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[3];
        // Act
        bool result = service.AddUser("test", client.Name, client.Email, new DateTime(1995, 12, 1), client.ClientId);
        // Assert
        Assert.That(result == true);
    }

    [Test]
    public void User_Service_Add_Service_Should_Return_True_For_Client_4()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[4];
        // Act
        bool result = service.AddUser("test", client.Name, client.Email, new DateTime(1995, 12, 1), client.ClientId);
        // Assert
        Assert.That(result == true);
    }

    [Test]
    public void User_Service_Add_Service_Should_Return_True_For_Client_5()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[5];
        // Act
        bool result = service.AddUser("test", client.Name, client.Email, new DateTime(1995, 12, 1), client.ClientId);
        // Assert
        Assert.That(result == true);
    }

    [Test]
    public void User_Service_Add_Service_Should_Return_True_For_Client_6()
    {
        // Arrange
        UserService service = new UserService();
        Client client = ClientRepository.Database[6];
        // Act
        try
        {
            bool result = service.AddUser("test", client.Name, client.Email, new DateTime(1995, 12, 1),
                client.ClientId);
        }
        catch (ArgumentException e)
        {
            Assert.Pass();
        }

        // Assert
            Assert.Fail();
    }
}