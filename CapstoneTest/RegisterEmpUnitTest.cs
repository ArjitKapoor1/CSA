using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CybersecurityAwarenessPortal.Models;

namespace CapstoneUnitTests
{
    [TestClass]
    public class RegisterEmpUnitTest
    {
        [TestMethod]
        public void CheckSucessfulRegister()
        {
            // Arrange
            RegisterClientModel rcm = new RegisterClientModel();
            rcm.EmployeeID = 3;
            rcm.FirstName = "sean";
            rcm.LastName = "paul";
            rcm.LoginEmail = "sean.paul@tangerine.ca";
            rcm.Password = "sean123";
            rcm.Department = "IT Ops";
            rcm.JoiningDate = DateTime.Now;

            // Act
            string test = rcm.RegisterClient();

            // Assert
            Assert.AreEqual(test, "Success");
        }
    }
}
