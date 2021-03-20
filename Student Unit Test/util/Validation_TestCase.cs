using Book_Management.entity;
using Book_Management.util;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Unit_Test.util
{
    [TestFixture]
    class Validation_TestCase
    {
        
        [TestCase(20, 40)]
        [TestCase(20, 0)]
        [TestCase(-10, 0)]
        [TestCase(-10, -20)]

        public void TC01_GetInt(int min, int max)
        {
            min = Math.Min(min, max);
            max = Math.Max(min, max);

            string mgs = "Age: ";

            Mock<Validation> mock = new Mock<Validation>();

            mock.Setup(el => el.GetInt(mgs, min, max)).Returns(new Random().Next(min, max));


            int actual = mock.Object.GetInt(mgs, min, max);
            Console.WriteLine(actual);
            Assert.IsTrue((actual - min) * (max - actual) >= 0);
        }


        [TestCase("Id: ", "he140712")]
        [TestCase("First Name: ", "thanh")]
        [TestCase("Last Name: ", "giap")]
        public void TC02_GetString(string mgs, string expected)
        {
            Mock<Validation> mock = new Mock<Validation>();

            mock.Setup(el => el.GetString(mgs)).Returns(expected);

            Assert.AreEqual(expected, mock.Object.GetString(mgs));
        }


        [TestCase("he140712", "giap", "thanh", 21, "giapthanh20@gmail.com")]
        public void TC03_GetStudent(string id, string firstName, string lastName, int age, string email)
        {
            Mock<Validation> mock = new Mock<Validation>();

            mock.Setup(el => el.GetStudent()).Returns(new Student(id, firstName, lastName, age, email));

            Student actual = mock.Object.GetStudent();

            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(firstName, actual.FirstName);
            Assert.AreEqual(lastName, actual.LastName);
            Assert.AreEqual(age, actual.Age);
            Assert.AreEqual(email, actual.Email);
        }

        [TestCase("MAE101", "Math")]
        public void GetCourse(string id, string name)
        {
            Mock<Validation> mock = new Mock<Validation>();

            mock.Setup(el => el.GetCourse()).Returns(new Course(id, name));

            Course actual = mock.Object.GetCourse();

            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
        }

        [TestCase("MAE101", "HE140712", "Fall")]
        public void TC04_GetStudentCourse(string courseId, string studentId, string term)
        {
            Mock<Validation> mock = new Mock<Validation>();

            mock.Setup(el => el.GetStudentCourse()).Returns(new StudentCourse(courseId, studentId, term));

            StudentCourse actual = mock.Object.GetStudentCourse();

            Assert.AreEqual(studentId, actual.StudentId);
            Assert.AreEqual(courseId, actual.CourseId);
            Assert.AreEqual(term, actual.Term);
        }
    }
}
