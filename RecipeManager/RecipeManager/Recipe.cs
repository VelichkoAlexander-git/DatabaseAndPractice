using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Recipe
    {
        public string Description { get; set; }
        public Group Group { get; set; }
        public IngredientContainer Ingredients { get; set; }
        public String RecipeSteps { get; set; }

        public Recipe(string description, Group group, IngredientContainer ingredients, String recipeSteps)
        {
            this.Description = description;
            this.Group = group;
            this.Ingredients = ingredients;
            this.RecipeSteps = recipeSteps;
        }

        public override string ToString()
        {
            return string.Format($"Description : {Description}\nGroup : {Group}\nIngredients : {Ingredients}\nRecipeSteps : {RecipeSteps}");
        }
    }
}
