using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CybersecurityAwarenessPortal.Models;

namespace CapstoneUnitTests
{
    [TestClass]
    public class ResetAttemptsTest
    {
        [TestMethod]
        public void CheckIfResetSuccessful()
        {
            //Arrange
            ResetAttemptsModel ram = new ResetAttemptsModel();
            ram.Name = "Arjit Kapoor";
            ram.Module = "Threats Overview";
            ram.ModuleNum = ram.GetModuleNum();
            ram.EmployeeID = ram.GetEmployeeID();

            //Act
            string result = ram.ResetAttempts();

            //Assert
            Assert.AreEqual(result, "Success");
        }
    }
}
