using Book_Management.ExceptionManagement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Unit_Test.util.exeption
{
    [TestFixture]
    class Exepion_TestClass
    {
        [TestCase("Key is not found")]
        public void TC01_throw_ContainKeyException(string message)
        {
            var ex = Assert.Throws<ContainKeyException>(() => throw new ContainKeyException(message));

            Assert.AreEqual(ex.Message, message);
        }

        [TestCase("Cannot Update Course")]
        public void TC02_throw_CannotUpdateCourseException(string message)
        {
            var ex = Assert.Throws<CannotUpdateCourseException>(() => throw new CannotUpdateCourseException(message));

            Assert.AreEqual(ex.Message, message);
        }

        [TestCase("Cannot Update Student")]
        public void TC03_throw_CannotUpdateStudentException(string message)
        {
            var ex = Assert.Throws<CannotUpdateStudentException>(() => throw new CannotUpdateStudentException(message));

            Assert.AreEqual(ex.Message, message);
        }


        [TestCase("Cannot Update Student Course")]
        public void TC01_throw_CannotUpdateStudentCourseException(string message)
        {
            var ex = Assert.Throws<CannotUpdateStudentCourseException>(() => throw new CannotUpdateStudentCourseException(message));

            Assert.AreEqual(ex.Message, message);
        }



        [TestCase("Student Course")]
        public void TC01_throw_StudentCourseException(string message)
        {
            var ex = Assert.Throws<StudentCourseException>(() => throw new StudentCourseException(message));

            Assert.AreEqual(ex.Message, message);
        }


    }


    }



