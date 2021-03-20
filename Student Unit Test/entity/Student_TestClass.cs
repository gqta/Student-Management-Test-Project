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
        [TestCase("","","",0,"")]
        public void TC01_Constructor(string id, string firstName, string lastName, int age, string email)
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
        public void TC02_StudentId_GetterAndSetter(string id)
        {
            Student st = new Student();
            st.Id = id;

            Assert.AreEqual(st.Id, id);
        }
        
        [TestCase("Tuan")]
        [TestCase("")]
        public void TC03_StudentFirstName_GetterAndSetter(string fName)
        {
            Student st = new Student();
            st.FirstName = fName;

            Assert.AreEqual(st.FirstName, fName);
        }


        [TestCase("Hung")]
        [TestCase("")]
        public void TC04_StudentLastName_GetterAndSetter(string lastName)
        {
            Student st = new Student();
            st.LastName = lastName;

            Assert.AreEqual(st.LastName, lastName);
        }


        [TestCase(30)]
        [TestCase(0)]
        [TestCase(-5)]
        public void TC05_StudentAge_GetterAndSetter(int age)
        {
            Student st = new Student();
            st.Age = age;

            Assert.AreEqual(st.Age, age);
        }

        [TestCase("TuanHung@gmail.com")]
        [TestCase("")]
        public void TC06_StudentEmail_GetterAndSetter(string email)
        {
            Student st = new Student();
            st.Email = email;

            Assert.AreEqual(st.Email, email);
        }
        [TestCase("1", "Tuan", "Hung", 30, "tuanhung@gmail.com")]
        [TestCase("", "", "", 0, "")]
        public void TC07_ToString(string id, string firstName, string lastName, int age, string email)
        {
            Student st = new Student(id, firstName, lastName, age, email);

            string expected = "\n----------" + id + "---------\n" +
                "Id: " + id + "\n" +
                "First Name: " + firstName + "\n" +
                "Last Name: " + lastName + "\n" +
                "Age: " + age.ToString() + "\n" +
                "Email: " + email;

            Assert.AreEqual(st.ToString(), expected);

        }


    }
}
