using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    public class Telephone
    {
        public string Number { get; set; }
        public string Group { get; set; }


        public Telephone(string number, string group)
        {
            this.Number = number;
            this.Group = group;
        }

        public Telephone()
            : this("Empty", "Empty")
        {
        }
    }
}
