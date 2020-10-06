using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Ingredient
    {
        public string Name { get; set; }

        protected Ingredient(string name)
        {
            this.Name = name;
        }

        public static Result<Ingredient> Create(string name)
        {
            var errors = new List<string>();
            
            if (string.IsNullOrEmpty(name)) { errors.Add("Название не может быть пустым"); }            

            if (errors.Any())
            {
                return Result<Ingredient>.Fail(errors);
            }
            return Result<Ingredient>.Success(new Ingredient(name));
        }

        public override string ToString()
        {
            return string.Format($"Name : {Name}");
        }
    }
}
