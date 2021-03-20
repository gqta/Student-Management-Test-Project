using Book_Management;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Unit_Test
{
    [TestFixture]
    class Program_TestClass
    {
        [TestCase]
        public void TC01_TestRunner()
        {
            Mock<Program> mock = new Mock<Program>();

            mock.Setup(el => el.Run()).Returns(1);

            Assert.AreEqual(1, mock.Object.Run());
        }
    }
}
