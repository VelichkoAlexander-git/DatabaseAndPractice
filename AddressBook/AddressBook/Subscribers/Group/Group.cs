using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Group
    {
        public string Name { get; set; }

        protected Group(string name)
        {
            Name = name;
        }
        protected Group()
        { }

        public static Result<Group> Create(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(name)) { errors.Add("Название не может быть пустым"); }

            if (errors.Any())
            {
                return Result<Group>.Fail(errors);
            }
            return Result<Group>.Success(new Group(name));
        }
        public override string ToString()
        {
            return string.Format($"Group : {Name}");
        }
    }
}
