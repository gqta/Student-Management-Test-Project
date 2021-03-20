using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.entity
{
    [Serializable]
    public class Student : IComparable<Student>
    {

        private string id;
        private string firstName;
        private string lastName;
        private int age;
        private string email;

        public Student(string id, string firstName, string lastName, int age, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
        {
            return

                "\n----------" + Id + "---------\n" +
                "Id: " + Id + "\n" +
                "First Name: " + firstName + "\n" +
                "Last Name: " + lastName + "\n" +
                "Age: " + Age.ToString() + "\n" +
                "Email: " + Email;
        }

        public int CompareTo(Student other)
        {
            return this.id.CompareTo(other.Id);
        }
    }
}
