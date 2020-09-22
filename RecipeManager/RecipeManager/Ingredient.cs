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

        public Ingredient(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format($"Name : {Name}");
        }
    }
}
