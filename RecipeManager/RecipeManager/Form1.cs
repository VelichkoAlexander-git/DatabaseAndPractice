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
        private string filePath
        {
            get
            {
                return ConfigurationManager.AppSettings["recipesFileName"];
            }
            set
            {
                ConfigurationManager.AppSettings["recipesFileName"] = value;
            }
        }

        private ObjectStorage _storage;

        public Form1()
        {
            InitializeComponent();

            _storage = ObjectStorage.GetInstance();

            _storage.GetRecipe().Changed += RecipeContainer_Changed;
            _storage.GetIngredient().Changed += IngredientContainer_Changed;
            _storage.GetIngredient().Changed += RecipeContainer_Changed;
            _storage.GetGroups().Changed += GroupContainer_Changed;
            _storage.GetGroups().Changed += RecipeContainer_Changed;

            mainListView.ItemSelectionChanged += mainListView_ItemSelectionChanged;
            lvIngredient.ItemSelectionChanged += lvIngredient_ItemSelectionChanged;
            lvGroup.ItemSelectionChanged += lvGroup_ItemSelectionChanged;

            RecipeContainer_Changed(this, new EventArgs());
            IngredientContainer_Changed(this, new EventArgs());
            GroupContainer_Changed(this, new EventArgs());
        }

        #region XmlCteatAndLoad
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Save this file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.Yes:
                    var data = new RecipeManagerData
                    {
                        Ingredients = _storage.GetIngredient().ToList(),
                        Recipes = _storage.GetRecipe().ToList(),
                        Groups = _storage.GetGroups().ToList()
                    };

                    if (!File.Exists(filePath))
                    {
                        SaveFileDialog saveFile = new SaveFileDialog();
                        saveFile.Filter = "Xml (*.dat)|*.dat|All Files (*.*)|*.*";
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            filePath = saveFile.FileName;
                            RecipeDataManager.SaveData(filePath, data);
                        }
                    }
                    else
                    {
                        RecipeDataManager.SaveData(filePath, data);
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RecipeManagerData data = null;
            if (!File.Exists($@"{filePath}"))
            {
                MessageBox.Show("File to download not found", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Xml (*.dat)|*.dat|All Files (*.*)|*.*";
                openFile.FilterIndex = 1;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFile.FileName;
                    data = RecipeDataManager.LoadData(filePath);

                }
            }
            else
            {
                data = RecipeDataManager.LoadData(filePath);
            }

            _storage.SetData(data);
        }
        #endregion

        #region tabRecipe
        private void mainListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (mainListView.SelectedItems.Count == 0)
            {
                lvIngredientsRecipe.Items.Clear();
                vlRevipeSteps.Items.Clear();
                return;
            }

            int index = mainListView.SelectedIndices[0];

            lvIngredientsRecipe.Items.Clear();
            for (int i = 0; i < _storage.GetRecipe()[index].Ingredients.Count(); i++)
            {
                lvIngredientsRecipe.Items.Add(new ListViewItem(new string[] {
                    _storage.GetRecipe()[index].Ingredients[i].Name}));
            }

            vlRevipeSteps.Items.Clear();
            vlRevipeSteps.Items.Add(new ListViewItem(new string[] {
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

            mainListView_ItemSelectionChanged(this, null);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            RecipeForm addForm = new RecipeForm(_storage);
            addForm.ShowDialog();

            if (addForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                _storage.GetRecipe().Add(addForm.Recipe);
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (mainListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Recipe recipe = _storage.GetRecipe().ElementAt(mainListView.SelectedIndices[0]);
                RecipeForm addForm = new RecipeForm(_storage, recipe);
                addForm.ShowDialog();

                if (addForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _storage.GetRecipe().Remove(mainListView.SelectedIndices[0]);
                    _storage.GetRecipe().Add(addForm.Recipe);
                }
            }
        }
        #endregion

        #region tabIngredient
        private void IngredientContainer_Changed(object sender, EventArgs e)
        {
            lvIngredient.Items.Clear();

            for (int i = 0; i < _storage.GetIngredient().Count(); i++)
            {
                lvIngredient.Items.Add(new ListViewItem(new string[] {
                    _storage.GetIngredient()[i].Name}));
            }
        }

        private void lvIngredient_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvIngredient.SelectedItems.Count == 0)
            {
                return;
            }

            int index = lvIngredient.SelectedIndices[0];
            txtNameIngr.Text = _storage.GetIngredient()[index].Name;
        }

        private void btnAddIngr_Click(object sender, System.EventArgs e)
        {
            var createResult = Ingredient.Create(txtNameIngr.Text);
            if (!createResult.Succeeded)
            {
                MessageBox.Show(string.Join(Environment.NewLine, createResult.Errors), "Ошибка создания ингредиента", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _storage.GetIngredient().Add(createResult.Value);
            }
        }

        private void btnDeleteIngr_Click(object sender, EventArgs e)
        {
            if (lvIngredient.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int index = lvIngredient.SelectedIndices[0];
                if (!CheckingRecipeForAnIngredient(_storage.GetIngredient()[index]))
                {
                    _storage.GetIngredient().Remove(index);
                }
                else
                {
                    MessageBox.Show("Этот ингредиент находится в рецепте", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void btnEditIngr_Click(object sender, EventArgs e)
        {
            if (lvIngredient.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int index = lvIngredient.SelectedIndices[0];
                _storage.GetIngredient().Edit(index, txtNameIngr.Text);
            }
        }
        #endregion

        #region tabGroup
        private void GroupContainer_Changed(object sender, EventArgs e)
        {
            lvGroup.Items.Clear();

            for (int i = 0; i < _storage.GetGroups().Count(); i++)
            {
                lvGroup.Items.Add(new ListViewItem(new string[] {
                    _storage.GetGroups()[i].Name}));
            }
        }

        private void lvGroup_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvGroup.SelectedItems.Count == 0)
            {
                return;
            }

            int index = lvGroup.SelectedIndices[0];
            txtNameGrou.Text = _storage.GetGroups()[index].Name;
        }

        private void btnAddGrou_Click(object sender, System.EventArgs e)
        {
            var createResult = Group.Create(txtNameGrou.Text);
            if (!createResult.Succeeded)
            {
                MessageBox.Show(string.Join(Environment.NewLine, createResult.Errors), "Ошибка создания группы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _storage.GetGroups().Add(createResult.Value);
            }
        }

        private void btnDeleteGrou_Click(object sender, EventArgs e)
        {
            if (lvGroup.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int index = lvGroup.SelectedIndices[0];
                if (!CheckingRecipeForAnGroup(_storage.GetGroups()[index]))
                {
                    _storage.GetGroups().Remove(index);
                }
                else
                {
                    MessageBox.Show("Эта группа находится в рецепте", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnEditGrou_Click(object sender, EventArgs e)
        {
            if (lvGroup.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int index = lvGroup.SelectedIndices[0];
                _storage.GetGroups().Edit(index, txtNameGrou.Text);
            }
        }
        #endregion

        private bool CheckingRecipeForAnGroup(Group group)
        {
            return _storage.GetRecipe().Any(r => r.Group.Name == group.Name);
        }
        private bool CheckingRecipeForAnIngredient(Ingredient ingredient)
        {
            foreach (var recipe in _storage.GetRecipe())
            {
                if (recipe.Ingredients.Any(i => i.Name == ingredient.Name)) return true;
            }
            return false;
        }

    }
}
