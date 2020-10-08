using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace RecipeManager {

    public class RecipeManagerData {
        public List<Ingredient> Ingredients { get; set; }
        //public List<Group> Groups { get; set; }
    }

    public class RecipeDataManager {

        private string _fileName;

        public RecipeDataManager(string fileName) {
            _fileName = fileName;
        }

        public bool SaveData(ObjectStorage storage) {
            var data = new RecipeManagerData {
                Ingredients = storage.GetIngredient().ToList()
            };

            using (var stream = new FileStream(_fileName, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(RecipeManagerData));
                serializer.Serialize(stream, data);
            }


            return true;
        }

        public bool LoadData(ObjectStorage storage) {
            throw new NotImplementedException();
        }

    }
}
