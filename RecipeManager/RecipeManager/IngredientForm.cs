﻿using System;
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
    public partial class IngredientForm : Form
    {
        private IngredientContainer _ingredient;
        public IngredientForm()
        {
            InitializeComponent();
            _ingredient = new IngredientContainer();
            _ingredient.Changed += _ingredient_Changed;
        }

        public Recipe Recipe { get; protected set; }

        private string SelectedGroup
        {
            get
            {
                if (cmbGroup.SelectedItem is null)
                {
                    return string.Empty;
                }
                return cmbGroup.SelectedItem.ToString();
            }
        }

        private void _ingredient_Changed(object sender, EventArgs e)
        {
            lvwAddIngredients.Items.Clear();

            for (int i = 0; i < _ingredient.Count(); i++)
            {
                lvwAddIngredients.Items.Add(new ListViewItem(new string[] { _ingredient[i].Name }));
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            AddIngredientForm formIngr = new AddIngredientForm();
            formIngr.ShowDialog();

            if (formIngr.DialogResult == System.Windows.Forms.DialogResult.OK)
                if (formIngr.Ingredient != null)
                _ingredient.Add(formIngr.Ingredient);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (lvwAddIngredients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _ingredient.Remove(lvwAddIngredients.SelectedIndices[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var createResult = Recipe.Create(txtDescription.Text, new Group(SelectedGroup), _ingredient, txtSteps.Text);
            if (!createResult.Succeeded)
            {
                MessageBox.Show(string.Join(Environment.NewLine, createResult.Errors), "Ошибка создания рецепта", MessageBoxButtons.OK, MessageBoxIcon.Error);
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