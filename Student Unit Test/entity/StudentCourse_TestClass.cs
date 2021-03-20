using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Management.entity;



namespace Student_Unit_Test
{
    [Serializable]
    [TestFixture]
     class StudentCourse_TestClass
    {
        [TestCase("C0068","HE14688","Java")]
        [TestCase("","","")]
        public void TC01_TestConstructorStudentCourse(string courseId, string studentId, string term)
        {

            StudentCourse stCourse = new StudentCourse(courseId, studentId, term);

            Assert.AreEqual(stCourse.CourseId, courseId);
            Assert.AreEqual(stCourse.StudentId, studentId);
            Assert.AreEqual(stCourse.Term, term);


        }
        [TestCase("C0001")]
        [TestCase("")]
        public void TC02_CourseId_GetterAndSetter(string courseId)
        {
            StudentCourse stCourse = new StudentCourse();
            stCourse.CourseId = courseId;

            Assert.AreEqual(stCourse.CourseId, courseId);

        }

        [TestCase("HE688")]
        [TestCase("")]
        public void TC03_StudentID_GetterAndSetter(string studentId)
        {
            StudentCourse stCourse = new StudentCourse();
            stCourse.StudentId = studentId;

            Assert.AreEqual(stCourse.StudentId, studentId);

        }

        [TestCase("Math")]
        [TestCase("")]
        public void TC04_CourseId_GetterAndSetter(string term)
        {
            StudentCourse stCourse = new StudentCourse();
            stCourse.Term = term;

            Assert.AreEqual(stCourse.Term, term);

        }

        [TestCase("C0001", "HE141026", "Fall")]
        [TestCase("", "", "")]
        public void TC05_GetHashKey(string courseId, string StudentId, string term)
        {

            StudentCourse studentCourse = new StudentCourse(courseId, StudentId, term);
            string expected = String.Format("{0}_{1}_{2}", courseId.ToLower(), StudentId.ToLower(), term.ToLower());

            Assert.AreEqual(expected, studentCourse.GetHashKey());
        }










    }
}
