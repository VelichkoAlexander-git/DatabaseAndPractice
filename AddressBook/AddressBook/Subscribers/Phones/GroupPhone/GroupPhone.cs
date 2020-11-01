using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class GroupPhone
    {
        public string Name { get; set; }

        protected GroupPhone(string name)
        {
            Name = name;
        }
        protected GroupPhone()
        { }

        public static Result<GroupPhone> Create(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(name)) { errors.Add("Название не может быть пустым"); }

            if (errors.Any())
            {
                return Result<GroupPhone>.Fail(errors);
            }
            return Result<GroupPhone>.Success(new GroupPhone(name));
        }
        public override string ToString()
        {
            return string.Format($"Group Phone : {Name}");
        }
    }
}
