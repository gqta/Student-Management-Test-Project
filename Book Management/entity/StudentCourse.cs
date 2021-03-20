using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.entity
{
    [Serializable]
     public class StudentCourse
    {
        private string courseId;
        private string studentId;
        private string term;

        public StudentCourse()
        {

        }

        public StudentCourse(string courseId, string studentId, string term)
        {
            this.courseId = courseId;
            this.studentId = studentId;
            this.term = term;
        }

        public string CourseId { get => courseId; set => courseId = value; }
        public string StudentId { get => studentId; set => studentId = value; }
        public string Term { get => term; set => term = value; }


        public string GetHashKey()
        {
            return String.Format("{0}_{1}_{2}", courseId.ToLower(), StudentId.ToLower(), term.ToLower());
        }
    }
}
