using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace RecipeManager
{
    public class ObjectStorage
    {
        #region Singleton
        private static readonly ObjectStorage instance = new ObjectStorage();

        public static ObjectStorage GetInstance()
        {
            return instance;
        }

        private ObjectStorage()
        {
            _ingredient = new IngredientContainer();
            _recipe = new RecipeContainer();

            _ingredient.Add(Ingredient.Create("Мыло").Value);
            _ingredient.Add(Ingredient.Create("Мясо").Value);
            _ingredient.Add(Ingredient.Create("Печенье").Value);

            var res = Recipe.Create(
                description: "ddd",
                group: new Group("tmp"),
                ingredients: new IngredientContainer(new List<Ingredient>() { _ingredient[0], _ingredient[1] }),
                recipeSteps: "fff"
                );  
            _recipe.Add(res.Value);
            
        }

        #endregion

        private IngredientContainer _ingredient;

        private RecipeContainer _recipe;

        public RecipeContainer GetRecipe()
        {
            return _recipe;
        }

        public IngredientContainer GetIngredient()
        {
            return _ingredient;
        }

    }
}
