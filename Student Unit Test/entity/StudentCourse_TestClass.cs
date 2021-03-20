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

        [TestCase]
        public void TC10_TestConstructorStudentCourse(string courseId, string studentId, string term)
        {

            StudentCourse stCourse = new StudentCourse(courseId, studentId, term);

            Assert.AreEqual(stCourse.CourseId, courseId);
            Assert.AreEqual(stCourse.StudentId, studentId);
            Assert.AreEqual(stCourse.Term, term);


        }

        [TestCase]
        public void TC11_CourseId_GetterAndSetter(string courseId)
        {
            StudentCourse stCourse = new StudentCourse();
            stCourse.CourseId = courseId;

            Assert.AreEqual(stCourse.CourseId, courseId);

        }

        [TestCase("C0001")]
        [TestCase("")]
        [TestCase(null)]
        public void TC12_StudentID_GetterAndSetter(string studentId)
        {
            StudentCourse stCourse = new StudentCourse();
            stCourse.StudentId = studentId;

            Assert.AreEqual(stCourse.CourseId, studentId);

        }

        [TestCase("Math")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase]
        public void TC11_CourseId_etterAndSetter(string courseId)
        {
            StudentCourse stCourse = new StudentCourse();
            stCourse.CourseId = courseId;

            Assert.AreEqual(stCourse.CourseId, courseId);

        }











    }
}
