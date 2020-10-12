using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeManager
{
    [Serializable]
    [XmlRoot(ElementName = "Recipes")]
    public class RecipeContainer : IEnumerable<Recipe>
    {
        public event EventHandler Changed;

        [XmlArrayItem("ListOfRecipe")]
        private List<Recipe> _list;

        public RecipeContainer(List<Recipe> RecipeList)
        {
            _list = RecipeList;
        }
        public RecipeContainer() : this(new List<Recipe>())
        {
        }

        #region Serialize
        public RecipeContainer(SerializationInfo info, StreamingContext context)
        {
            this._list = (List<Recipe>)info.GetValue("Recipes", typeof(List<Recipe>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Recipes", _list);
        }
        #endregion

        public Recipe this[int i]
        {
            get
            {
                return _list[i];
            }

            set
            {
                _list[i] = value;
            }
        }

        public RecipeContainer Add(Recipe recipe)
        {
            _list.Add(recipe);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public RecipeContainer SetList(List<Recipe> list)
        {
            _list = list;

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }


        public RecipeContainer Remove(Recipe recipe)
        {
            _list.Remove(recipe);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }
        public RecipeContainer Remove(int Index)
        {
            _list.RemoveAt(Index);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public int Count()
        {
            return _list.Count;
        }

        public IEnumerator<Recipe> GetEnumerator()
        {
            return ((IEnumerable<Recipe>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
