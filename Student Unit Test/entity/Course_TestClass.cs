using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Book_Management;
using Book_Management.entity;

namespace Student_Unit_Test
{
    [TestFixture]
    class Course_TestClass
    {
       
        [TestCase("1", "Java")]
        [TestCase("", "")]
        [TestCase(null, null)]

        public void TC01_Constructor_InitConstructor(string id, string name)
        {
            Course course = new Course(id,name);

            Assert.AreEqual(course.Id, id);
            Assert.AreEqual(course.Name, name);
       
        }

        [TestCase("1")]
        [TestCase("")]
        [TestCase(null)]
        public void TC02_CourseId_GetterAndSetter(string id)
        {

                Course course = new Course();
                course.Id = id;

                Assert.AreEqual(course.Id, id);

        }

        [TestCase("Java")]
        [TestCase("")]
        [TestCase(null)]
        public void TC03_CourseName_GetterAndSetter(string name)
        {

            Course course = new Course();
            course.Name = name;

            Assert.AreEqual(course.Name, name);

        }





    }
}
