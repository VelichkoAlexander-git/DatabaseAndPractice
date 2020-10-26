using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class RecipeForm : Form
    {
        private ObjectStorage _storage;
        private IngredientContainer _ingredient;

        public RecipeForm(ObjectStorage storage)
        {
            _storage = storage;
            InitializeComponent();
            groupListCmb();

            _ingredient = new IngredientContainer();
            _ingredient.Changed += ingredient_Changed;

        }

        public RecipeForm(ObjectStorage storage, Recipe recipe) : this (storage)
        {
            txtDescription.Text = recipe.Description; 
            SelectedGroup = recipe.Group;
            _ingredient = recipe.Ingredients;
            _ingredient.Changed += ingredient_Changed;
            ingredient_Changed(this, new EventArgs());
            txtSteps.Text = recipe.RecipeSteps;
        }

        public Recipe Recipe { get; protected set; }

        private Group SelectedGroup
        {
            get
            {
                if (cmbGroup.SelectedItem is null)
                {
                    return Group.Create(string.Empty).Value;
                }
                return _storage.GetGroups().ElementAt(cmbGroup.SelectedIndex);
            }
            set 
            {
                cmbGroup.SelectedIndex = _storage.GetGroups()[value];
            }
        }

        private void ingredient_Changed(object sender, EventArgs e)
        {
            lvAddIngredients.Items.Clear();

            for (int i = 0; i < _ingredient.Count(); i++)
            {
                lvAddIngredients.Items.Add(new ListViewItem(new string[] { _ingredient[i].Name }));
            }
        }

        private void groupListCmb()
        {
            cmbGroup.Items.Clear();
            foreach (var item in _storage.GetGroups())
            {
                cmbGroup.Items.Add(item.Name);
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            AddIngredientForm formIngr = new AddIngredientForm(_storage.GetIngredient());
            formIngr.ShowDialog();

            if (formIngr.DialogResult == System.Windows.Forms.DialogResult.OK)
                if (formIngr.Ingredient != null)
                _ingredient.Add(formIngr.Ingredient);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (lvAddIngredients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one item from the list", "Delete error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _ingredient.Remove(lvAddIngredients.SelectedIndices[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var createResult = Recipe.Create(txtDescription.Text, SelectedGroup, _ingredient, txtSteps.Text);
            if (!createResult.Succeeded)
            {
                MessageBox.Show(string.Join(Environment.NewLine, createResult.Errors), "Recipe creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Recipe = createResult.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
