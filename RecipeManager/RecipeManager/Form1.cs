using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        private ObjectStorage _storage;

        public Form1()
        {
            InitializeComponent();

            _storage = ObjectStorage.GetInstance();
            Form1_Load();

            _storage.GetRecipe().Changed += RecipeContainer_Changed;
            RecipeContainer_Changed(this, new EventArgs());
            mainListView.ItemSelectionChanged += mainListView_ItemSelectionChanged;
        }

        #region XmlCteatAndLoad
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string filePath = ConfigurationManager.AppSettings["recipesFileName"];
            var manager = new RecipeDataManager(filePath);
            manager.SaveData(ObjectStorage.GetInstance());
        }
        private void Form1_Load()
        {
            string filePath = ConfigurationManager.AppSettings["recipesFileName"];
            var manager = new RecipeDataManager(filePath);
            manager.LoadData(ObjectStorage.GetInstance());
        }
        #endregion

        private void mainListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (mainListView.SelectedItems.Count == 0)
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                return;
            }

            int index = mainListView.SelectedIndices[0];

            listView1.Items.Clear();
            for (int i = 0; i < _storage.GetRecipe()[index].Ingredients.Count(); i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    _storage.GetRecipe()[index].Ingredients[i].Name}));
            }

            listView2.Items.Clear();
            listView2.Items.Add(new ListViewItem(new string[] {
                    _storage.GetRecipe()[index].RecipeSteps}));
        }

        private void RecipeContainer_Changed(object sender, EventArgs e)
        {
            mainListView.Items.Clear();

            for (int i = 0; i < _storage.GetRecipe().Count(); i++)
            {
                mainListView.Items.Add(new ListViewItem(new string[] {
                    _storage.GetRecipe()[i].Description,
                    _storage.GetRecipe()[i].Group.Name}));
            }
        }
        private void addButton_Click(object sender, System.EventArgs e)
        {
            IngredientForm addForm = new IngredientForm(_storage);
            addForm.ShowDialog();

            if (addForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                _storage.GetRecipe().Add(addForm.Recipe);
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            if (mainListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _storage.GetRecipe().Remove(mainListView.SelectedIndices[0]);
            }
        }
    }
}
