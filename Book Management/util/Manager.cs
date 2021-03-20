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
    class Manager : IManager
    {

        public string studentFile = "student.bin";
        public string courseFile = "course.bin";
        public string studentCourseFile = "studentCourse.bin";

        private Dictionary<String, Student> lstStudent;
        private Dictionary<String, Course> lstCourse;
        private Dictionary<String, StudentCourse> lstStudentCourse;

        public Manager()
        {
            LoadCourseFromFile();
            LoadStudentFromFile();
            LoadStudentCourseFromFile();
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
                SaveCourseToFile();
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
                lstStudent.Add(student.Id, student);SaveStudentToFile();
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
                    SaveStudentCourseToFile();
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
                SaveCourseToFile();
                return true;
            }
            return false;
        }

        public bool DeleteStudent(string id)
        {
            if (lstStudent.ContainsKey(id))
            {
                lstStudent.Remove(id);SaveStudentToFile();
                return true;

            }

            return false;
            

        }

        public bool DeleteStudentCourse(StudentCourse studentCourse)
        {

            if (lstStudentCourse.ContainsKey(studentCourse.GetHashKey()))
            {
                lstStudentCourse.Remove(studentCourse.GetHashKey());
                SaveStudentCourseToFile();
                return true;
            }
            return false;

        }

        public bool EditCourse(Course course)
        {

            if (lstCourse.ContainsKey(course.Id))
            {
                lstCourse[course.Id] = course;SaveCourseToFile();
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
                lstStudent[student.Id] = student; SaveStudentToFile();
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
                SaveStudentCourseToFile();
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

        public int LoadCourseFromFile()
        {
            try
            {
                using (Stream stream = File.Open(this.studentFile, FileMode.Open))
                {
                    var binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    this.lstStudent = (Dictionary<string, Student>)binFormatter.Deserialize(stream);
                }
            }catch(FileNotFoundException ex)
            {
                this.lstStudent = new Dictionary<string, Student>();
                return -1;
            }
            return this.lstStudent.Count;

        }

        public int LoadStudentCourseFromFile()
        {
            try
            {

                using (Stream stream = File.Open(this.courseFile, FileMode.Open))
                {
                    var binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    this.lstCourse = (Dictionary<string, Course>)binFormatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                this.lstCourse = new Dictionary<string, Course>();
                return -1;
            }
            return this.lstCourse.Count;
        }

        public int LoadStudentFromFile()
        {
            try
            {
                using (Stream stream = File.Open(this.studentCourseFile, FileMode.Open))
                {
                    var binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    this.lstStudentCourse = (Dictionary<string, StudentCourse>)binFormatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                this.lstStudentCourse = new Dictionary<string, StudentCourse>();
                return -1;
            }
            return this.lstStudent.Count;
        }

        public int SaveCourseToFile()
        {
            using (Stream stream = File.OpenWrite(courseFile))
            {
                var binFrt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                binFrt.Serialize(stream, this.lstCourse);
            }

            return lstCourse.Count();        
        }

        public int SaveStudentCourseToFile()
        {
            using (Stream stream = File.OpenWrite(studentFile))
            {
                var binFrt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                binFrt.Serialize(stream, this.lstStudentCourse);
            }

            return lstStudentCourse.Count();
        }

        public int SaveStudentToFile()
        {
            using (Stream stream = File.OpenWrite(studentFile))
            {
                var binFrt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                binFrt.Serialize(stream, this.lstStudent);
            }

            return lstStudent.Count();
        }
    }
}
