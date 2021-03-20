using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.ExceptionManagement
{
    class ContainKeyException : Exception
    {
        public ContainKeyException(string message) : base(message)
        {
            
        }
        
    }
    class CannotUpdateCourseException : Exception
    {
        public CannotUpdateCourseException(string message) : base(message)
        {

        }
    }
    class CannotUpdateStudentException : Exception
    {
        public CannotUpdateStudentException(string message) : base(message)
        {

        }
    }
    class CannotUpdateStudentCourseException : Exception
    {
        public CannotUpdateStudentCourseException(string message) : base(message)
        {

        }
    }
    class StudentCourseException : Exception
    {
        public StudentCourseException(string message) : base(message)
        {

        }
    }
}
