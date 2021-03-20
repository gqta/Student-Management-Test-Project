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
        public void TC01_AddCourse_Success(string courseId, string courseName)
        {
            IManager manager = new Manager();


            Assert.AreEqual(true, manager.AddCourse(new Course(courseId, courseName)));

            var ex = Assert.Throws<ContainKeyException>(() => manager.AddCourse(new Course(courseId, courseName)));
            Assert.That(ex.Message, Is.EqualTo("Id has been existed!!"));

        }

        [TestCase("1", "Discrete mathematic")]
        [TestCase("", "")]
        public void TC02_AddCourse_Falure(string courseId, string courseName)
        {
            IManager manager = new Manager();

            manager.AddCourse(new Course(courseId, courseName));

            var ex = Assert.Throws<ContainKeyException>(() => manager.AddCourse(new Course(courseId, courseName)));
            Assert.That(ex.Message, Is.EqualTo("Id has been existed!!"));

        }

        [TestCase("1", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC03_AddStudent_Success(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
        {
            IManager manager = new Manager();

            Assert.AreEqual(true, manager.AddStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email)));



        }

        [TestCase("1", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC04_AddStudent_Failure(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
        {
            IManager manager = new Manager();

            manager.AddStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email));


            var ex = Assert.Throws<ContainKeyException>(() => manager.AddStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email)));
            Assert.That(ex.Message, Is.EqualTo("Id has been existed!!"));

        }

        [TestCase("1", "1", "blah")]
        [TestCase("", "", "")]
        public void TC05_AddStudentCourse_Success(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            manager.AddCourse(new Course(courseId, ""));
            Assert.AreEqual(true, manager.AddStudentCourse(new StudentCourse(courseId, studentId, term)));
        }



        [TestCase("1", "1", "blah")]
        public void TC05_AddStudentCourse_ContainKeyException(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            manager.AddCourse(new Course(courseId, ""));
            manager.AddStudentCourse(new StudentCourse(courseId, studentId, term));
            var ex = Assert.Throws<ContainKeyException>(() => manager.AddStudentCourse(new StudentCourse(courseId, studentId, term)));
            Assert.AreEqual(ex.Message, "Id has been existed!!");
        }




        [TestCase("1", "1", "blah")]
        public void TC06_AddStudentCourse_MissingStudent_StudentCourseException(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddCourse(new Course(courseId, ""));
            var ex = Assert.Throws<StudentCourseException>(() => manager.AddStudentCourse(new StudentCourse(courseId, studentId, term)));
            Assert.AreEqual(ex.Message, "Cannot add this studentCourse!!!");
        }



        [TestCase("1", "1", "blah")]
        public void TC07_AddStudentCourse_MissingCourse_StudentCourseException(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            var ex = Assert.Throws<StudentCourseException>(() => manager.AddStudentCourse(new StudentCourse(courseId, studentId, term)));
            Assert.AreEqual(ex.Message, "Cannot add this studentCourse!!!");
        }


        [TestCase("1")]
        [TestCase("")]
        public void TC08_DeleteCourse(string courseId)
        {
            IManager manager = new Manager();
            manager.AddCourse(new Course(courseId, ""));
            Assert.IsTrue(manager.DeleteCourse(courseId));
        }


        [TestCase("1")]
        public void TC09_DeleteCourse_ReturnFalse(string courseId)
        {
            IManager manager = new Manager();

            Assert.AreEqual(false, manager.DeleteCourse(courseId));
        }



        [TestCase("1")]
        [TestCase("")]
        public void TC10_DeleteStudent(string studentId)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            Assert.IsTrue(manager.DeleteStudent(studentId));
        }



        [TestCase("1")]
        [TestCase("")]
        public void TC11_DeleteStudent_ReturnFalse(string studentId)
        {
            IManager manager = new Manager();
            Assert.IsFalse(manager.DeleteStudent(studentId));
        }



        [TestCase("1", "1", "blah")]
        [TestCase("", "", "")]
        public void TC12_DeleteStudentCourse(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            manager.AddCourse(new Course(courseId, ""));
            manager.AddStudentCourse(new StudentCourse(studentId, courseId, term));
            Assert.IsTrue(manager.DeleteStudentCourse(new StudentCourse(courseId, studentId, term)));

        }


        [TestCase("1", "1", "blah")]
        [TestCase("", "", "")]
        public void TC13_DeleteStudentCourse_ReturnFalse(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            Assert.IsFalse(manager.DeleteStudentCourse(new StudentCourse(courseId, studentId, term)));

        }

        [TestCase("1", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC14_EditStudent_Success(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", studentAge, ""));
            Assert.IsTrue(manager.EditStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email)));

        }


        [TestCase("1", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC15_EditStudent_Failure(string studentId, string studentFirstName, string studentLastName, int studentAge, string email)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student("1231321", "", "", studentAge, ""));
            var ex = Assert.Throws<CannotUpdateStudentException>(() => manager.EditStudent(new Student(studentId, studentFirstName, studentLastName, studentAge, email)));
            Assert.AreEqual(ex.Message, "Cannot Update Student " + studentLastName);
        }

        [TestCase("1", "1")]
        [TestCase("", "")]
        public void TC16_EditCourse_Success(string courseId, string courseName)
        {
            IManager manager = new Manager();
            manager.AddCourse(new Course(courseId, courseName));
            Assert.IsTrue(manager.EditCourse(new Course(courseId, courseName)));

        }


        [TestCase("1", "1")]
        [TestCase("", "")]
        public void TC17_EditCourse_Failure(string courseId, string courseName)
        {
            IManager manager = new Manager();
            manager.AddCourse(new Course("321321321", courseName));
            var ex = Assert.Throws<CannotUpdateCourseException>(() => manager.EditCourse(new Course(courseId, courseName)));
            Assert.AreEqual(ex.Message, "Cannot Update Course " + courseName);

        }



        [TestCase("1", "1", "")]
        [TestCase("", "", "")]
        public void TC18_EditStudentCourse_Success(string courseId, string studentId, string term)
        {
            IManager manager = new Manager();
            manager.AddStudent(new Student(studentId, "", "", 0, ""));
            manager.AddCourse(new Course(courseId, ""));
            manager.AddStudentCourse(new StudentCourse(studentId, courseId, ""));
            Assert.IsTrue(manager.EditStudentCourse(new StudentCourse(courseId, studentId, term)));

        }

        [TestCase]
        public void TC19_GetStudentReport()
        {
            Student student = new Student("HE141010", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com");
            IManager manager = new Manager();
            manager.AddStudent(student);
            string output = student.ToString();
            string actual = String.IsNullOrEmpty(output) ? "\nStudent List is Empty!!\n" : "\n" + output + "\n";
            Assert.AreEqual(actual, manager.GetStudentReport());

        }

        [TestCase]
        public void TC20_GetCourseReport()
        {
            Course course = new Course("1", "Discrete Mathematics");
            IManager manager = new Manager();
            manager.AddCourse(course);
            string output = course.ToString();
            string actual = String.IsNullOrEmpty(output) ? "\nCourse List is Empty!!\n" : "\n" + output + "\n";
            Assert.AreEqual(actual, manager.GetCourseReport());

        }


        [TestCase]
        public void TC21_GetStudentCourseReport()
        {
            Student student = new Student("HE141010", "Tung", "Ha Vu Son", 21, "havusontung007@gmail.com");
            Course course = new Course("1", "Discrete Mathematics");
            StudentCourse studentCourse = new StudentCourse("1", "HE141010", "termWhat?");
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
