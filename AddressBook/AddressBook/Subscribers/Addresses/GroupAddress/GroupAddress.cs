using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class GroupAddress
    {
        public string Name { get; set; }

        protected GroupAddress(string name)
        {
            Name = name;
        }
        protected GroupAddress()
        { }

        public static Result<GroupAddress> Create(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(name)) { errors.Add("Название не может быть пустым"); }

            if (errors.Any())
            {
                return Result<GroupAddress>.Fail(errors);
            }
            return Result<GroupAddress>.Success(new GroupAddress(name));
        }
        public override string ToString()
        {
            return string.Format($"Group Addres : {Name}");
        }
    }
}
