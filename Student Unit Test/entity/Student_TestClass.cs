using Book_Management.entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Unit_Test
{
    [TestFixture]
    class Student_TestClass
    {
        [TestCase("1", "Tuan","Hung",30,"tuanhung@gmail.com")]
        [TestCase(null, null, null, null,null)]
        public void TC04_Constructor(string id, string firstName, string lastName, int age, string email)
        {
            Student st = new Student(id, firstName, lastName, age, email);

            Assert.AreEqual(st.Id, id);
            Assert.AreEqual(st.FirstName, firstName);
            Assert.AreEqual(st.LastName, lastName);
            Assert.AreEqual(st.Age, age);
            Assert.AreEqual(st.Email, email);


        }

        [TestCase("1")]
        [TestCase("")]
        [TestCase(null)]
        public void TC05_StudentId_GetterAndSetter(string id)
        {
            Student st = new Student();
            st.Id = id;

            Assert.AreEqual(st.Id, id);
        }
        
        [TestCase("Tuan")]
        [TestCase("")]
        [TestCase(null)]

        public void TC06_StudentFirstName_GetterAndSetter(string fName)
        {
            Student st = new Student();
            st.FirstName = fName;

            Assert.AreEqual(st.FirstName, fName);
        }


        [TestCase("Hung")]
        [TestCase("")]
        [TestCase(null)]
        public void TC07_StudentLastName_GetterAndSetter(string lastName)
        {
            Student st = new Student();
            st.LastName = lastName;

            Assert.AreEqual(st.LastName, lastName);
        }


        [TestCase(30)]
        [TestCase(null)]
        public void TC08_StudentAge_GetterAndSetter(int age)
        {
            Student st = new Student();
            st.Age = age;

            Assert.AreEqual(st.Age, age);
        }

        [TestCase("TuanHung@gmail.com")]
        [TestCase("")]
        [TestCase(null)]
        public void TC09_StudentEmail_GetterAndSetter(string email)
        {
            Student st = new Student();
            st.Email = email;

            Assert.AreEqual(st.Email, email);
        }


    }
}
