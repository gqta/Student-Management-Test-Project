using Book_Management.entity;
using Book_Management.ExceptionManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.util
{
    class Manager : IManager
    {
        private Dictionary<String, Student> lstStudent;
        private Dictionary<String, Course> lstCourse;
        private Dictionary<String, StudentCourse> lstStudentCourse;

        public Manager()
        {
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

        public bool DeleteCourse(Course course)
        {
            if (lstCourse.ContainsKey(course.Id))
            {
                lstCourse.Remove(course.Id);
                return true;
            }
            return false;
        }

        public bool DeleteStudent(Student student)
        {
            if (lstStudent.ContainsKey(student.Id))
            {
                lstStudent.Remove(student.Id);
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
                throw new CannotUpdateCourseException("Cannot Delete Course " + course.Name);
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
                throw new CannotUpdateStudentException("Cannot Delete Student " + student.LastName);
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
                throw new CannotUpdateStudentCourseException("Cannot Delete this StudentCourse ");
            }
        }

        public string GetCourseReport()
        {
            string output = "";
            foreach (var x in lstCourse)
            {
                output += x.Value.ToString();
            }
            return output;
        }

        public string GetStudentCourseReport()
        {
            string output = "";
            foreach (var x in lstStudentCourse)
            {
                output += x.Value.ToString();
            }
            return output;
        }

        public string GetStudentReport()
        {
            string output = "";
            foreach (var x in lstStudent)
            {
                output += x.Value.ToString();
            }
            return output;
        }

        public int LoadData()
        {
            throw new NotImplementedException();
        }

        public int SaveData()
        {
            throw new NotImplementedException();
        }
    }
}
