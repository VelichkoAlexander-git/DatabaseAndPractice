using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeManager
{
    [Serializable]
    public class Group
    {
        [XmlAttribute(AttributeName = "Name")]
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

            if (string.IsNullOrEmpty(name)) { errors.Add("Title cannot be empty"); }


            if (errors.Any())
            {
                return Result<Group>.Fail(errors);
            }

            var context = Regex.Replace(name, @"\s+", " ").Trim();
            return Result<Group>.Success(new Group(context));
        }
        public override string ToString()
        {
            return string.Format($"Name : {Name}");
        }
    }
}
