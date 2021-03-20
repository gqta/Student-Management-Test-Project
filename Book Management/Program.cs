﻿using Book_Management.entity;
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
                "10. Show Student Report\n" +
                "11. Show Course Report\n" +
                "12. Show Student Course Report\n" +
                "0. Exit\n" +
                "=>>";

            while (true)
            {
                int choice = valid.GetInt(menu, 0, 10);

                switch (choice)
                {
                    case 1:
                        try
                        {
                            manager.AddStudent(valid.GetStudent());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;

                    case 2:
                        try
                        {
                            manager.EditStudent(valid.GetStudent());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 3:
                        try
                        {
                            manager.DeleteStudent(valid.GetString("Student Id: "));
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 4:
                        try
                        {
                            manager.AddCourse(valid.GetCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }

                        break;
                    case 5:
                        try
                        {
                            manager.EditCourse(valid.GetCourse());
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
                            manager.AddStudentCourse(valid.GetStudentCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;


                    case 8:
                        try
                        {
                            manager.EditStudentCourse(valid.GetStudentCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;


                    case 9:
                        try
                        {
                            manager.DeleteStudentCourse(valid.GetStudentCourse());
                        }
                        catch
                        {
                            Console.WriteLine();
                        }
                        break;
                    case 10:
                        Console.WriteLine(manager.GetStudentReport());
                        break;
                    case 11:
                        Console.WriteLine(manager.GetCourseReport());
                        break;
                    case 12:
                        Console.WriteLine(manager.GetStudentCourseReport());
                        break;

                    case 0:
                        return;

                }

            }
        }

        



    }
}
