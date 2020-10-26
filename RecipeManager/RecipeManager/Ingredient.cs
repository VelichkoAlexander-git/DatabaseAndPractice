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
    public class Ingredient
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        protected Ingredient(string name)
        {
            this.Name = name;
        }

        protected Ingredient()
        {

        }

        public static Result<Ingredient> Create(string name)
        {
            var errors = new List<string>();
            
            if (string.IsNullOrEmpty(name)) { errors.Add("Title cannot be empty"); }            

            if (errors.Any())
            {
                return Result<Ingredient>.Fail(errors);
            }

            var context = Regex.Replace(name, @"\s+", " ").Trim();
            return Result<Ingredient>.Success(new Ingredient(context));
        }

        public override string ToString()
        {
            return string.Format($"Name : {Name}");
        }
    }
}
