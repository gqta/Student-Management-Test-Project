using Book_Management.entity;
using Book_Management.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management
{
    class Program
    {
        static Validation valid = new Validation();
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            string menu = "-------Student Management--------\n" +
                "1. Add Student\n" +
                "2. Edit Student\n" +
                "3. Delete Student\n" +
                "4. Add Course\n" +
                "5. Edit Course\n" +
                "6. Delete Course\n" +
                "7. Add Student Course\n" +
                "8. Edit Student Course\n" +
                "9. Delete Student Course \n" +
                "0. Exit\n" +
                "=>>";
            bool running = true;
            while (running)
            {
                int choice = valid.GetInt(menu, 0, 10);

                switch (choice)
                {
                    case 1:
                        try
                        {
                            manager.AddStudent(GetStudent());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;

                    case 2:
                        try
                        {
                            manager.EditStudent(GetStudent());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 3:
                        try
                        {
                            manager.DeleteCourse(valid.GetString("Student Id: "));
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 4:
                        try
                        {
                            manager.AddCourse(GetCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 5:
                        try
                        {
                            manager.EditCourse(GetCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 6:
                        try
                        {
                            manager.DeleteCourse(valid.GetString("Course Id: "));
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;


                    case 7:
                        try
                        {
                            manager.AddStudentCourse(GetStudentCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;


                    case 8:
                        try
                        {
                            manager.EditStudentCourse(GetStudentCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;


                    case 9:
                        try
                        {
                            manager.DeleteStudentCourse(GetStudentCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;

                    case 0:
                        running = false;
                        return;

                }

            }
        }

        public static Student GetStudent()
        {
            string id = valid.GetString("Id: ");
            string firstName = valid.GetString("First Name: ");
            string lastName = valid.GetString("Last Name: ");
            int age = valid.GetInt("Age: ", 6, 100);
            string email = valid.GetString("Email: ");
            return new Student(id, firstName, lastName, age, email);
        }

        public static Course GetCourse()
        {
            string id = valid.GetString("Id: ");
            string name = valid.GetString("Name: ");
            return new Course(id, name);
        }

        public static StudentCourse GetStudentCourse()
        {
            string studentId = valid.GetString("Student Id: ");
            string coursetId = valid.GetString("Course Id: ");
            string term = valid.GetString("Term: ");
            return new StudentCourse(coursetId, studentId, term);
        }



    }
}
