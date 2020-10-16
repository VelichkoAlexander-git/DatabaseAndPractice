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

    public class RecipeDataManager
    {

        private string _fileName;

        public RecipeDataManager(string fileName)
        {
            _fileName = fileName;
        }

        public bool SaveData(ObjectStorage storage)
        {
            var data = new RecipeManagerData
            {
                Ingredients = storage.GetIngredient().ToList(),
                Recipes = storage.GetRecipe().ToList(),
                Groups = storage.GetGroups().ToList()
            };

            if (!File.Exists(_fileName))
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Xml (*.dat)|*.dat|All Files (*.*)|*.*";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    _fileName = saveFile.FileName;
                }
            }
            using (var stream = new FileStream(_fileName, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(RecipeManagerData));
                serializer.Serialize(stream, data);
            }


            return true;
        }

        public bool LoadData(ObjectStorage storage)
        {
            if (!File.Exists($@"{_fileName}"))
            {
                //убрать
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Xml (*.dat)|*.dat|All Files (*.*)|*.*";
                openFile.FilterIndex = 1;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ConfigurationManager.AppSettings["recipesFileName"] = openFile.FileName;
                    _fileName = openFile.FileName;
                    LoadData(storage);
                }
            }
            else
            {
                using (var fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
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

                    storage.SetData(starage);
                }
            }

            return true;
        }
    }
}
