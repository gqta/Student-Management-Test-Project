using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.ExceptionManagement
{
    public class ContainKeyException : Exception
    {
        public ContainKeyException(string message) : base(message)
        {
            
        }
        
    }
    public class CannotUpdateCourseException : Exception
    {
        public CannotUpdateCourseException(string message) : base(message)
        {

        }
    }
    public class CannotUpdateStudentException : Exception
    {
        public CannotUpdateStudentException(string message) : base(message)
        {

        }
    }
    public class CannotUpdateStudentCourseException : Exception
    {
        public CannotUpdateStudentCourseException(string message) : base(message)
        {

        }
    }
    public class StudentCourseException : Exception
    {
        public StudentCourseException(string message) : base(message)
        {

        }
    }
}
