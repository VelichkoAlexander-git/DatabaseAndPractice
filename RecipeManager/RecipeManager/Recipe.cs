using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager
{
    public class Recipe
    {
        public string Description { get; set; }
        public Group Group { get; set; }
        public IngredientContainer Ingredients { get; set; }
        public string RecipeSteps { get; set; }

        // прячем конструктор, чтобы запретить создание объектов напрямую
        protected Recipe(string description, Group group, IngredientContainer ingredients, string recipeSteps)
        {
            this.Description = description; // this не нужно указывать без явной необходимости (а она довольно редко возникает)
            Group = group;
            Ingredients = ingredients;
            RecipeSteps = recipeSteps;
        }

        // для контролируемого создания новых рецептов
        public static Result<Recipe> Create(string description, Group group, IngredientContainer ingredients, string recipeSteps)
        {
            var errors = new List<string>();

            if (group is null) throw new ArgumentNullException(nameof(group));
            if (string.IsNullOrEmpty(description)) {errors.Add("Описание не может быть пустым");}
            if (string.IsNullOrEmpty(recipeSteps)) {errors.Add("Необходимо указать шаги рецепта");}
            if (ingredients.Count() == 0){errors.Add("Рецепт должен содержать ингредиенты");}

            if (errors.Any())
            {
                return Result<Recipe>.Fail(errors);
            }
            return Result<Recipe>.Success(new Recipe(description, group, ingredients, recipeSteps));
        }

        public override string ToString()
        {
            return string.Format($"Description : {Description}\nGroup : {Group}\nIngredients : {Ingredients}\nRecipeSteps : {RecipeSteps}");
        }
    }
}
