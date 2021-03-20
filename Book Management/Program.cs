using Book_Management.entity;
using Book_Management.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management
{
    public class Program
    {

        public virtual int Run()
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

                try
                {
                switch (choice)
                {
                    case 1:
                        manager.AddStudent(valid.GetStudent());
                        break;
                    case 2:
                        manager.EditStudent(valid.GetStudent());
                        break;
                    case 3:
                        manager.DeleteStudent(valid.GetString("Student Id: "));
                        break;
                    case 4:
                        manager.AddCourse(valid.GetCourse());
                        break;
                    case 5:
                        manager.EditCourse(valid.GetCourse());
                        break;
                    case 6:
                        manager.DeleteCourse(valid.GetString("Course Id: "));
                        break;
                    case 7:
                        manager.AddStudentCourse(valid.GetStudentCourse());
                        break;
                    case 8:
                        manager.EditStudentCourse(valid.GetStudentCourse());
                        break;

                    case 9:
                        manager.DeleteStudentCourse(valid.GetStudentCourse());
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
                        return 1;

                }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }
        static Validation valid = new Validation();
        static void Main(string[] args)
        {
            new Program().Run();
        }





    }
}
