using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Book_Management;
using Book_Management.entity;
using Book_Management.util;
using Book_Management.ExceptionManagement;
namespace Student_Unit_Test.util
{
    [TestFixture]
    class Manager_TestClass
    {
        [TestCase("1", "Discrete mathematic")]
        [TestCase("", "")]
        public void TC_01_AddCourse(string courseId, string courseName)
        {
            IManager manager = new Manager();
            try
            {

                Assert.AreEqual(true, manager.AddCourse(new Course(courseId, courseName)));
            }
            catch (Exception e)
            {
                var ex = Assert.Throws<ContainKeyException>(() => manager.AddCourse(new Course(courseId, courseName)));
                Assert.That(ex.Message, Is.EqualTo("Id has been existed!!"));
            }


        }

        [TestCase("1", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC_02_AddStudent(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
        {
            IManager manager = new Manager();
            try
            {
                Assert.AreEqual(true, manager.AddStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email)));
            }
            catch (ContainKeyException ex)
            {
                Assert.AreEqual(ex.Message, "Id has been existed!!");
            }


        }


        [TestCase("1", "1", "blah")]
        public void TC_03_AddStudentCourse(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            try
            {
                Assert.AreEqual(true, manager.AddStudentCourse(new StudentCourse(courseId, studentId, term)));
            }
            catch (ContainKeyException ex)
            {
                Assert.AreEqual(ex.Message, "Id has been existed!!");
            }
            catch (StudentCourseException ex)
            {
                Assert.AreEqual(ex.Message, "Cannot add this studentCourse!!!");
            }


        }


        [TestCase("1")]
        public void TC_04_DeleteCourse(string courseId)
        {
            IManager manager = new Manager();
            Assert.AreEqual(true, manager.DeleteCourse(courseId));
        }
    }
}
