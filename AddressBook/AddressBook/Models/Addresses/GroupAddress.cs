using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class GroupAddress
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int AddressId { get; protected set; }
        public virtual Address Address { get; protected set; }

        public int UserId { get; protected set; }
        public virtual User User { get; protected set; }

        protected GroupAddress()
        { }

        public static Result<GroupAddress> Create(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(name)) { errors.Add(" Name is required"); }

            if (errors.Any())
            {
                return Result<GroupAddress>.Fail(errors);
            }

            var newGroupAddress = new GroupAddress
            {
                Name = name
            };
            return Result<GroupAddress>.Success(newGroupAddress);
        }
        public override string ToString()
        {
            return string.Format($"Group Addres : {Name}");
        }
    }
}
