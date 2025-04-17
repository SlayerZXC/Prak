using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Windows.Forms;
using курсовая_трзбд;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private Form4 form;

        [TestInitialize]
        public void Setup()
        {
            form = new Form4();
        }

        [TestMethod]
        public void AddClient_ValidData_ClientAdded()
        {
            form.AddClient("1", "John Doe", "1234567890");
            Assert.IsTrue(form.IsClientAdded);
        }

        [TestMethod]
        public void AddClient_InvalidData_ErrorMessageShown()
        {
            form.AddClient("", "John Doe", "1234567890");
            Assert.IsTrue(form.IsErrorMessageShown);
        }

        [TestMethod]
        public void UpdateClient_ValidData_ClientUpdated()
        {
            form.AddClient("2", "Jane Doe", "0987654321"); // Ensure client exists first
            form.UpdateClient("2", "Jane Smith", "0987654321");
            Assert.IsTrue(form.IsClientUpdated);
        }

        [TestMethod]
        public void UpdateClient_InvalidData_ErrorMessageShown()
        {
            form.UpdateClient("", "Jane Smith", "0987654321");
            Assert.IsTrue(form.IsErrorMessageShown);
        }

      


        [TestMethod]
        public void DeleteClient_InvalidId_ErrorMessageShown()
        {
            form.DeleteClient("");
            Assert.IsTrue(form.IsErrorMessageShown);
        }
    }
}
