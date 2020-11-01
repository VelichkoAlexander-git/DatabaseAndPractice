using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Address
    {
        public string Information { get; set; }

        public GroupAddress Group { get; set; }

        protected Address(string number, GroupAddress group)
        {
            Information = number;
            Group = group;
        }

        protected Address()
        { }

        public static Result<Address> Create(string information, GroupAddress group)
        {
            var errors = new List<string>();

            if (errors.Any())
            {
                return Result<Address>.Fail(errors);
            }
            return Result<Address>.Success(new Address(information, group));
        }
        public override string ToString()
        {
            return string.Format($"Address | Info : {Information}, {Group}");
        }
    }
}
