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
                    storage.SetData((RecipeManagerData)serializer.Deserialize(fileStream));
                }
            }

            return true;
        }
    }
}
