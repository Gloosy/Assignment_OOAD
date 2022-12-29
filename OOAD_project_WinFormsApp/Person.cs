using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_project_WinFormsApp
{
    // Base Interface of (Decorator pattern)
    public interface IPerson
    {
        int id { get; set; }
        string name { get; set; }

        string phone { get; set; }

        string gender { get; set; }
        int age { get; set; }

    }
    // Base Concrete class of (Decorator pattern) 
    class Person : IPerson
    {
        public int id { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String gender { get; set; }
        public int age { get; set; }

    }
}
