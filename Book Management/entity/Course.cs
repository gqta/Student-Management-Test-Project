using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Management.entity
{
    [Serializable]
    public class Course
    {
        private string id;
        private string name;

        public Course()
        {

        }

        public Course(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public override string ToString()
        {
            return Id + "||" + Name + "\n";
        }
    }

}
