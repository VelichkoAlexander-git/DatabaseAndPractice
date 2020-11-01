using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Phone
    {
        public string Number { get; set; }

        public GroupPhone Group { get; set; }

        protected Phone(string number, GroupPhone group)
        {
            Number = number;
            Group = group;
        }

        protected Phone()
        { }

        public static Result<Phone> Create(string number, GroupPhone group)
        {
            var errors = new List<string>();

            if (errors.Any())
            {
                return Result<Phone>.Fail(errors);
            }
            return Result<Phone>.Success(new Phone(number, group));
        }

        public override string ToString()
        {
            return string.Format($"Phone | Num : {Number}, {Group}");
        }
    }
}
