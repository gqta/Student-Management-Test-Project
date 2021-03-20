using Book_Management.entity;
using Book_Management.ExceptionManagement;
using Book_Management.util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Unit_Test.util
{
    [TestFixture]
    class Manage_TestClass
    {
        [TestCase("1", "Discrete mathematic")]
        [TestCase("", "")]
        public void TC01_AddCourse(string courseId, string courseName)
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
        public void TC02_AddStudent(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
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
        [TestCase("", "", "")]
        public void TC03_AddStudentCourse(string courseId, string studentId, string term)
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
        [TestCase("")]
        public void TC04_DeleteCourse(string courseId)
        {
            IManager manager = new Manager();
            manager.AddCourse(new Course(courseId, ""));
            Assert.IsTrue(manager.DeleteCourse(courseId));
        }
        [TestCase("1")]
        public void TC05_DeleteCourse_ReturnFalse(string courseId)
        {
            IManager manager = new Manager();

            Assert.AreEqual(false, manager.DeleteCourse(courseId));
        }



        [TestCase("1")]
        [TestCase("")]
        public void TC06_DeleteStudent(string studentId)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            Assert.IsTrue(manager.DeleteStudent(studentId));
        }


        [TestCase("1")]
        [TestCase("")]
        public void TC07_DeleteStudent_ReturnFalse(string studentId)
        {
            IManager manager = new Manager();
            Assert.IsFalse(manager.DeleteStudent(studentId));
        }


        [TestCase("1", "1", "blah")]
        [TestCase("", "", "")]
        public void TC08_DeleteStudentCourse(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId,"", "", 0, ""));
            manager.AddCourse(new Course(courseId,""));
            manager.AddStudentCourse(new StudentCourse(studentId, courseId, term));
            Assert.IsTrue(manager.DeleteStudentCourse(new StudentCourse(courseId, studentId, term)));

        }

        [TestCase("1", "1", "blah")]
        [TestCase("", "", "")]
        public void TC09_DeleteStudentCourse_ReturnFalse(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            Assert.IsFalse(manager.DeleteStudentCourse(new StudentCourse(courseId, studentId, term)));

        }

        [TestCase("1", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC10_EditStudent(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
        {
            IManager manager = new Manager();
            try
            {
                manager.AddStudent(new Student(studentId, "", "", studentAge, ""));
                Assert.IsTrue(manager.EditStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email)));
            }
            catch(CannotUpdateCourseException ex)
            {
                Assert.AreEqual(ex.Message, "Cannot Update Student " + studentLastName);
            }
        }

        [TestCase("1", "1")]
        [TestCase("", "")]
        public void TC11_EditCourse(string courseId, string courseName)
        {
            IManager manager = new Manager();
            try
            {
                manager.AddCourse(new Course(courseId, courseName));
                Assert.IsTrue(manager.EditCourse(new Course(courseId, courseName)));
            }
            catch (CannotUpdateCourseException ex)
            {
                Assert.AreEqual(ex.Message, "Cannot Update Course " + courseName);
            }
        }


        [TestCase("1", "1","")]
        [TestCase("", "","")]
        public void TC12_EditStudentCourse(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            try
            {
                manager.AddStudent(new Student(studentId, "", "", 0, ""));
                manager.AddCourse(new Course(courseId, ""));
                manager.AddStudentCourse(new StudentCourse(studentId, courseId, ""));
                Assert.IsTrue(manager.EditStudentCourse(new StudentCourse(courseId, studentId,term)));
            }
            catch (CannotUpdateStudentCourseException ex)
            {
                Assert.AreEqual(ex.Message, "Cannot Update this StudentCourse ");
            }
        }

        [TestCase]
        public void TC13_GetStudentReport()
        {
            Student student = new Student("HE141010","Tung","Ha Vu Son",21,"havusontung007@gmail.com");
            IManager manager = new Manager();
            manager.AddStudent(student);
            string output = student.ToString();
            string actual = String.IsNullOrEmpty(output) ? "\nStudent List is Empty!!\n" : "\n" + output + "\n";
            Assert.AreEqual(actual, manager.GetStudentReport());
           
        }

        [TestCase]
        public void TC14_GetCourseReport()
        {
            Course course = new Course("1","Discrete Mathematics");
            IManager manager = new Manager();
            manager.AddCourse(course);
            string output = course.ToString();
            string actual = String.IsNullOrEmpty(output) ? "\nCourse List is Empty!!\n" : "\n" + output + "\n";
            Assert.AreEqual(actual, manager.GetCourseReport());

        }


        [TestCase]
        public void TC15_GetStudentCourseReport()
        {
            Student student = new Student("HE141010", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com");
            Course course = new Course("1", "Discrete Mathematics");
            StudentCourse studentCourse = new StudentCourse("1","HE141010","termWhat?");
            IManager manager = new Manager();
            manager.AddCourse(course);
            manager.AddStudent(student);
            manager.AddStudentCourse(studentCourse);
            string output = studentCourse.ToString();
            string actual = String.IsNullOrEmpty(output) ? "\nStudentCourse List is Empty!!\n" : "\n" + output + "\n";
            Assert.AreEqual(actual, manager.GetStudentCourseReport());

        }


    }

}
