using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesApp.Models;
using NotesApp.Services;
using NotesApp.Services.Helpers;
using NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.UnitTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Authenticate_ValdiUsernamePassword_ValidToken()
        {
            //Arrange
            string username = "Bob007";
            string password = "asdqwe123";
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "Secret for testing"
            });
            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);


            //ACT
            UserModel result = userService.Authenticate(username, password);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Token != null && result.Token != string.Empty);
        }
        [TestMethod]
        public void Authenticate_ValdiUsernamePassword_Null()
        {
            //Arrange
            string username = "Bob007";
            string password = "qweqweasdqe";
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "Secret for testing"
            });
            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);


            //ACT
            UserModel result = userService.Authenticate(username, password);

            //Assert
            Assert.IsNull(result);
            
        }

        [TestMethod]
        public void Register_ValidData_RegisteredUser()
        {
            //Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "Secret for testing"
            });
            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);
            RegisterModel user = new RegisterModel
            {
                FirstName = "Greg",
                LastName = "Gregsky",
                Password = "asdqwe123",
                ConfirmPassword = "asdqwe123",
                Username = "greggregsky",
            };
            //Act

            userService.Register(user);
            //Assert

            UserModel newUser = userService.Authenticate(user.Username, user.Password);
            Assert.AreEqual(user.FirstName, newUser.FirstName);
            Assert.AreEqual(user.LastName, newUser.LastName);
        }
    }
}
