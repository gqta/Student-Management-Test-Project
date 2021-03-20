using Book_Management.entity;
using System;
using System.Text.RegularExpressions;

namespace Book_Management.util
{
    public class Validation
    {
        public virtual int GetInt(string mgs, int min, int max)
        {

            min = Math.Min(min, max);
            max = Math.Max(min, max);
            while (true)
            {
                Console.Write(mgs);

                try
                {
                    int result = Int32.Parse(Console.ReadLine());

                    if ((result) >= min || result <= max) return result;
                        
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must an integer from {0} to {1}", min, max);
                }
                
            }
        }

        public virtual string GetString(string mgs)
        {
            while (true)
            {
                Console.Write(mgs);

                string input = Console.ReadLine();

                if(Regex.IsMatch(input, @"[a-zA-Z]"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Input must be an string!");
                }
            }
        }

        public virtual  Student GetStudent()
        {
            string id = GetString("Id: ");
            string firstName = GetString("First Name: ");
            string lastName = GetString("Last Name: ");
            int age = GetInt("Age: ", 6, 100);
            string email = GetString("Email: ");
            return new Student(id, firstName, lastName, age, email);
        }

        public virtual Course GetCourse()
        {
            string id = GetString("Id: ");
            string name = GetString("Name: ");
            return new Course(id, name);
        }

        public virtual  StudentCourse GetStudentCourse()
        {
            string studentId =  GetString("Student Id: ");
            string coursetId = GetString("Course Id: ");
            string term = GetString("Term: ");
            return new StudentCourse(coursetId, studentId, term);
        }
    }
}
