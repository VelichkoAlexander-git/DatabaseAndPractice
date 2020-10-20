using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RecipeManager
{

    public class RecipeManagerData
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Group> Groups { get; set; }
        public List<Recipe> Recipes { get; set; }
    }

    public static class RecipeDataManager
    {
        public static void SaveData(string path, RecipeManagerData storage)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(RecipeManagerData));
                serializer.Serialize(stream, storage);
            }
        }

        public static RecipeManagerData LoadData(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(RecipeManagerData));
                var starage = (RecipeManagerData)serializer.Deserialize(fileStream);

                List<Recipe> tmpRecipes = new List<Recipe>();
                foreach (var itemRecipe in starage.Recipes)
                {
                    IngredientContainer ingredients = new IngredientContainer();
                    Ingredient tmpIngredient;
                    foreach (var itemIngredient in itemRecipe.Ingredients)
                    {
                        tmpIngredient = starage.Ingredients.FindLast(t => t.Name == itemIngredient.Name);
                        ingredients.Add(tmpIngredient);
                    }
                    Group group = starage.Groups.FindLast(t => t.Name == itemRecipe.Group.Name);
                    Recipe recipe = Recipe.Create(itemRecipe.Description, group, ingredients, itemRecipe.RecipeSteps).Value;
                    tmpRecipes.Add(recipe);
                }
                starage.Recipes = tmpRecipes;
                return starage;
            }
        }
    }
}
