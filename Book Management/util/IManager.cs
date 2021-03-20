using Book_Management.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.util
{
    interface IManager
    {
        int LoadData();

        int SaveData();

        

        // return true if student is added
        // throw ex if somwthing exsited -> if key is exsit -> throw StudentCourseExeption();
        bool AddStudent(Student student);

        // return true if Course is added 
        // throw ex if somwthing exsited -> if key is exsit -> throw StudentCourseExeption();
        bool AddCourse(Course course);

        // return true if Course is Added 
        // throw ex if somwthing exsited -> if key is exsit -> throw StudentCourseExeption();
        bool AddStudentCourse(StudentCourse studentCourse);

        // check id and override data
        // if id exsited and data is valid -> override else throw Ex
        bool EditStudent(Student student);


        // same with edit student
        bool EditCourse(Course course);

        // same with edit student
        bool EditStudentCourse(StudentCourse studentCourse);

        // if id exsited -> delete and return else throw ex;
        bool DeleteStudent(string id);


        bool DeleteCourse(string id);


        bool DeleteStudentCourse(StudentCourse studentCourse);


        string GetStudentCourseReport();
        string GetStudentReport();
        string GetCourseReport();



    }
}
