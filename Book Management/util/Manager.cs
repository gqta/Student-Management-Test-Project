using Book_Management.entity;

using Book_Management.ExceptionManagement;
using System;
using System.Collections;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.util
{
    public class Manager : IManager
    {

        private Dictionary<String, Student> lstStudent;
        private Dictionary<String, Course> lstCourse;
        private Dictionary<String, StudentCourse> lstStudentCourse;

        public Manager()
        {
            this.lstCourse = new Dictionary<string, Course>();
            this.lstStudent = new Dictionary<string, Student>();
            this.lstStudentCourse = new Dictionary<string, StudentCourse>();
        }

        public bool AddCourse(Course course)
        {
            if (lstCourse.ContainsKey(course.Id))
            {
                throw new ContainKeyException("Id has been existed!!");
            }
            else
            {
                lstCourse.Add(course.Id, course);
               
                return true;
            }


        }

        public bool AddStudent(Student student)
        {

            if (lstStudent.ContainsKey(student.Id))
            {
                throw new ContainKeyException("Id has been existed!!");
            }
            else
            {
                lstStudent.Add(student.Id, student);
                return true;
            }
            

        }

        public bool AddStudentCourse(StudentCourse studentCourse)
        {

            if (lstStudentCourse.ContainsKey(studentCourse.GetHashKey()))
            {
                throw new ContainKeyException("Id has been existed!!");
            }
            else
            {
                if (lstStudent.ContainsKey(studentCourse.StudentId) && lstCourse.ContainsKey(studentCourse.CourseId))
                {
                    lstStudentCourse.Add(studentCourse.GetHashKey(), studentCourse);
                   
                    return true;
                }
                else
                {
                    throw new StudentCourseException("Cannot add this studentCourse!!!");
                }
            }
        }

        public bool DeleteCourse(string id)
        {
            if (lstCourse.ContainsKey(id))
            {
                lstCourse.Remove(id);
               
                return true;
            }
            return false;
        }

        public bool DeleteStudent(string id)
        {
            if (lstStudent.ContainsKey(id))
            {
                lstStudent.Remove(id);
                return true;

            }

            return false;
            

        }

        public bool DeleteStudentCourse(StudentCourse studentCourse)
        {

            if (lstStudentCourse.ContainsKey(studentCourse.GetHashKey()))
            {
                lstStudentCourse.Remove(studentCourse.GetHashKey());
                
                return true;
            }
            return false;

        }

        public bool EditCourse(Course course)
        {

            if (lstCourse.ContainsKey(course.Id))
            {
                lstCourse[course.Id] = course;
                return true;
            }
            else
            {
                throw new CannotUpdateCourseException("Cannot Update Course " + course.Name);
            }
            

        }

        public bool EditStudent(Student student)
        {

            if (lstStudent.ContainsKey(student.Id))
            {
                lstStudent[student.Id] = student;
                return true;
            }

            else
            {
                throw new CannotUpdateStudentException("Cannot Update Student " + student.LastName);
            }


        }

        public bool EditStudentCourse(StudentCourse studentCourse)
        {

            if (lstStudentCourse.ContainsKey(studentCourse.GetHashKey()))
            {
                lstStudentCourse[studentCourse.CourseId] = studentCourse;
                
                return true;
            }
            else
            {
                throw new CannotUpdateStudentCourseException("Cannot Update this StudentCourse ");
            }

        }

        public string GetCourseReport()
        {

            string output = "";
            foreach (var x in lstCourse)
            {
                output += x.Value.ToString();
            }
            return  String.IsNullOrEmpty(output) ? "\nStudent Course List is Empty!!\n" : "\n"+output+"\n" ;

        }

        public string GetStudentCourseReport()
        {


            string output = "";
            foreach (var x in lstStudentCourse)
            {
                output += x.Value.ToString();
            }
            return String.IsNullOrEmpty(output) ? "\nStudent Course List is Empty!!\n" : "\n" + output + "\n"; ;

        }

        public string GetStudentReport()
        {

            string output = "";
            foreach (var x in lstStudent)
            {
                output += x.Value.ToString();
            }
            return String.IsNullOrEmpty(output)?"\nStudent List is Empty!!\n": "\n" + output + "\n";

        }
    }
}
