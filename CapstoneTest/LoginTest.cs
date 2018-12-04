using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Web.Mvc;
using CybersecurityAwarenessPortal.Controllers;
using CybersecurityAwarenessPortal.Models;

namespace CapstoneUnitTests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void CheckValidLogin()
        {
            // Arrange 
            LoginController lc = new LoginController();
            LoginModel lm = new LoginModel();

            string user = "kapooarj@sheridancollege.ca";
            string password = "test123";

            // Act
            bool result = lm.IsValid(user, password);

            // Assert
            Assert.AreEqual(result, true);
        }
    }
}
