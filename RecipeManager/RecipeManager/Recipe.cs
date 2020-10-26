using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace RecipeManager
{
    [Serializable]
    public class Recipe
    {
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }

        [XmlElement]
        public Group Group { get; set; }

        [XmlArray]
        public IngredientContainer Ingredients { get; set; }

        [XmlAttribute(AttributeName = "RecipeSteps")]
        public string RecipeSteps { get; set; }

        protected Recipe()
        {

        }

        protected Recipe(string description, Group group, IngredientContainer ingredients, string recipeSteps)
        {
            Description = description;
            Group = group;
            Ingredients = ingredients;
            RecipeSteps = recipeSteps;
        }

        public static Result<Recipe> Create(string description, Group group, IngredientContainer ingredients, string recipeSteps)
        {
            var errors = new List<string>();

            if (group is null) { errors.Add("The recipe must contain a group"); };
            if (string.IsNullOrEmpty(description)) { errors.Add("Description cannot be empty"); }
            if (string.IsNullOrEmpty(recipeSteps)) { errors.Add("Recipe steps must be specified"); }
            if (ingredients.Count() == 0) { errors.Add("The recipe must contain ingredients"); }

            if (errors.Any())
            {
                return Result<Recipe>.Fail(errors);
            }

            var context = Regex.Replace(description, @"\s+", " ").Trim();
            return Result<Recipe>.Success(new Recipe(context, group, ingredients, recipeSteps));
        }

        public override string ToString()
        {
            return string.Format($"Description : {Description}\nGroup : {Group}\nIngredients : {Ingredients}\nRecipeSteps : {RecipeSteps}");
        }
    }
}
