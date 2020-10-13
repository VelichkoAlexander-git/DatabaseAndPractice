namespace RecipeManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRecipe = new System.Windows.Forms.TabPage();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.vlRevipeSteps = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvIngredientsRecipe = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageIngredientGroup = new System.Windows.Forms.TabPage();
            this.txtNameGrou = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditGrou = new System.Windows.Forms.Button();
            this.btnDeleteGrou = new System.Windows.Forms.Button();
            this.btnAddGrou = new System.Windows.Forms.Button();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNameIngr = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.btnEditIngr = new System.Windows.Forms.Button();
            this.btnDeleteIngr = new System.Windows.Forms.Button();
            this.btnAddIngr = new System.Windows.Forms.Button();
            this.lvIngredient = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPageRecipe.SuspendLayout();
            this.tabPageIngredientGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRecipe);
            this.tabControl1.Controls.Add(this.tabPageIngredientGroup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(738, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRecipe
            // 
            this.tabPageRecipe.Controls.Add(this.btnEdit);
            this.tabPageRecipe.Controls.Add(this.btnDelete);
            this.tabPageRecipe.Controls.Add(this.btnAdd);
            this.tabPageRecipe.Controls.Add(this.vlRevipeSteps);
            this.tabPageRecipe.Controls.Add(this.lvIngredientsRecipe);
            this.tabPageRecipe.Controls.Add(this.mainListView);
            this.tabPageRecipe.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecipe.Name = "tabPageRecipe";
            this.tabPageRecipe.Size = new System.Drawing.Size(730, 396);
            this.tabPageRecipe.TabIndex = 0;
            this.tabPageRecipe.Text = "Recipes";
            this.tabPageRecipe.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(91, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(172, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(10, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Создать";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // vlRevipeSteps
            // 
            this.vlRevipeSteps.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.vlRevipeSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.vlRevipeSteps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.vlRevipeSteps.FullRowSelect = true;
            this.vlRevipeSteps.GridLines = true;
            this.vlRevipeSteps.HideSelection = false;
            this.vlRevipeSteps.Location = new System.Drawing.Point(507, 35);
            this.vlRevipeSteps.MultiSelect = false;
            this.vlRevipeSteps.Name = "vlRevipeSteps";
            this.vlRevipeSteps.ShowGroups = false;
            this.vlRevipeSteps.Size = new System.Drawing.Size(215, 358);
            this.vlRevipeSteps.TabIndex = 8;
            this.vlRevipeSteps.UseCompatibleStateImageBehavior = false;
            this.vlRevipeSteps.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "";
            this.columnHeader4.Text = "RecipeSteps";
            this.columnHeader4.Width = 210;
            // 
            // lvIngredientsRecipe
            // 
            this.lvIngredientsRecipe.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvIngredientsRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lvIngredientsRecipe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvIngredientsRecipe.FullRowSelect = true;
            this.lvIngredientsRecipe.GridLines = true;
            this.lvIngredientsRecipe.HideSelection = false;
            this.lvIngredientsRecipe.Location = new System.Drawing.Point(323, 35);
            this.lvIngredientsRecipe.MultiSelect = false;
            this.lvIngredientsRecipe.Name = "lvIngredientsRecipe";
            this.lvIngredientsRecipe.ShowGroups = false;
            this.lvIngredientsRecipe.Size = new System.Drawing.Size(178, 358);
            this.lvIngredientsRecipe.TabIndex = 7;
            this.lvIngredientsRecipe.UseCompatibleStateImageBehavior = false;
            this.lvIngredientsRecipe.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "";
            this.columnHeader3.Text = "Ingredients";
            this.columnHeader3.Width = 171;
            // 
            // mainListView
            // 
            this.mainListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.mainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.mainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.mainListView.FullRowSelect = true;
            this.mainListView.GridLines = true;
            this.mainListView.HideSelection = false;
            this.mainListView.Location = new System.Drawing.Point(10, 35);
            this.mainListView.MultiSelect = false;
            this.mainListView.Name = "mainListView";
            this.mainListView.ShowGroups = false;
            this.mainListView.Size = new System.Drawing.Size(307, 358);
            this.mainListView.TabIndex = 6;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Group";
            this.columnHeader2.Width = 147;
            // 
            // tabPageIngredientGroup
            // 
            this.tabPageIngredientGroup.Controls.Add(this.txtNameGrou);
            this.tabPageIngredientGroup.Controls.Add(this.label1);
            this.tabPageIngredientGroup.Controls.Add(this.btnEditGrou);
            this.tabPageIngredientGroup.Controls.Add(this.btnDeleteGrou);
            this.tabPageIngredientGroup.Controls.Add(this.btnAddGrou);
            this.tabPageIngredientGroup.Controls.Add(this.lvGroup);
            this.tabPageIngredientGroup.Controls.Add(this.txtNameIngr);
            this.tabPageIngredientGroup.Controls.Add(this.lblText);
            this.tabPageIngredientGroup.Controls.Add(this.btnEditIngr);
            this.tabPageIngredientGroup.Controls.Add(this.btnDeleteIngr);
            this.tabPageIngredientGroup.Controls.Add(this.btnAddIngr);
            this.tabPageIngredientGroup.Controls.Add(this.lvIngredient);
            this.tabPageIngredientGroup.Location = new System.Drawing.Point(4, 22);
            this.tabPageIngredientGroup.Name = "tabPageIngredientGroup";
            this.tabPageIngredientGroup.Size = new System.Drawing.Size(730, 396);
            this.tabPageIngredientGroup.TabIndex = 0;
            this.tabPageIngredientGroup.Text = "Ingredients/Groups";
            this.tabPageIngredientGroup.UseVisualStyleBackColor = true;
            // 
            // txtNameGrou
            // 
            this.txtNameGrou.Location = new System.Drawing.Point(512, 13);
            this.txtNameGrou.Name = "txtNameGrou";
            this.txtNameGrou.Size = new System.Drawing.Size(146, 20);
            this.txtNameGrou.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name";
            // 
            // btnEditGrou
            // 
            this.btnEditGrou.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditGrou.Location = new System.Drawing.Point(537, 39);
            this.btnEditGrou.Name = "btnEditGrou";
            this.btnEditGrou.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditGrou.Size = new System.Drawing.Size(75, 23);
            this.btnEditGrou.TabIndex = 21;
            this.btnEditGrou.TabStop = false;
            this.btnEditGrou.Text = "Изменить";
            this.btnEditGrou.UseVisualStyleBackColor = true;
            this.btnEditGrou.Click += new System.EventHandler(this.btnEditGrou_Click);
            // 
            // btnDeleteGrou
            // 
            this.btnDeleteGrou.Location = new System.Drawing.Point(618, 39);
            this.btnDeleteGrou.Name = "btnDeleteGrou";
            this.btnDeleteGrou.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeleteGrou.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteGrou.TabIndex = 20;
            this.btnDeleteGrou.TabStop = false;
            this.btnDeleteGrou.Text = "Удалить";
            this.btnDeleteGrou.UseVisualStyleBackColor = true;
            this.btnDeleteGrou.Click += new System.EventHandler(this.btnDeleteGrou_Click);
            // 
            // btnAddGrou
            // 
            this.btnAddGrou.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddGrou.Location = new System.Drawing.Point(456, 39);
            this.btnAddGrou.Name = "btnAddGrou";
            this.btnAddGrou.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddGrou.Size = new System.Drawing.Size(75, 23);
            this.btnAddGrou.TabIndex = 19;
            this.btnAddGrou.TabStop = false;
            this.btnAddGrou.Text = "Создать";
            this.btnAddGrou.UseVisualStyleBackColor = true;
            this.btnAddGrou.Click += new System.EventHandler(this.btnAddGrou_Click);
            // 
            // lvGroup
            // 
            this.lvGroup.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.GridLines = true;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(451, 68);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.ShowGroups = false;
            this.lvGroup.Size = new System.Drawing.Size(253, 320);
            this.lvGroup.TabIndex = 18;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "";
            this.columnHeader6.Text = "Groups";
            this.columnHeader6.Width = 248;
            // 
            // txtNameIngr
            // 
            this.txtNameIngr.Location = new System.Drawing.Point(88, 13);
            this.txtNameIngr.Name = "txtNameIngr";
            this.txtNameIngr.Size = new System.Drawing.Size(146, 20);
            this.txtNameIngr.TabIndex = 17;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(47, 16);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(35, 13);
            this.lblText.TabIndex = 16;
            this.lblText.Text = "Name";
            // 
            // btnEditIngr
            // 
            this.btnEditIngr.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditIngr.Location = new System.Drawing.Point(113, 39);
            this.btnEditIngr.Name = "btnEditIngr";
            this.btnEditIngr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditIngr.Size = new System.Drawing.Size(75, 23);
            this.btnEditIngr.TabIndex = 15;
            this.btnEditIngr.TabStop = false;
            this.btnEditIngr.Text = "Изменить";
            this.btnEditIngr.UseVisualStyleBackColor = true;
            this.btnEditIngr.Click += new System.EventHandler(this.btnEditIngr_Click);
            // 
            // btnDeleteIngr
            // 
            this.btnDeleteIngr.Location = new System.Drawing.Point(194, 39);
            this.btnDeleteIngr.Name = "btnDeleteIngr";
            this.btnDeleteIngr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeleteIngr.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteIngr.TabIndex = 13;
            this.btnDeleteIngr.TabStop = false;
            this.btnDeleteIngr.Text = "Удалить";
            this.btnDeleteIngr.UseVisualStyleBackColor = true;
            this.btnDeleteIngr.Click += new System.EventHandler(this.btnDeleteIngr_Click);
            // 
            // btnAddIngr
            // 
            this.btnAddIngr.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddIngr.Location = new System.Drawing.Point(32, 39);
            this.btnAddIngr.Name = "btnAddIngr";
            this.btnAddIngr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddIngr.Size = new System.Drawing.Size(75, 23);
            this.btnAddIngr.TabIndex = 12;
            this.btnAddIngr.TabStop = false;
            this.btnAddIngr.Text = "Создать";
            this.btnAddIngr.UseVisualStyleBackColor = true;
            this.btnAddIngr.Click += new System.EventHandler(this.btnAddIngr_Click);
            // 
            // lvIngredient
            // 
            this.lvIngredient.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lvIngredient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lvIngredient.FullRowSelect = true;
            this.lvIngredient.GridLines = true;
            this.lvIngredient.HideSelection = false;
            this.lvIngredient.Location = new System.Drawing.Point(27, 68);
            this.lvIngredient.MultiSelect = false;
            this.lvIngredient.Name = "lvIngredient";
            this.lvIngredient.ShowGroups = false;
            this.lvIngredient.Size = new System.Drawing.Size(253, 320);
            this.lvIngredient.TabIndex = 8;
            this.lvIngredient.UseCompatibleStateImageBehavior = false;
            this.lvIngredient.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "";
            this.columnHeader5.Text = "Ingredients";
            this.columnHeader5.Width = 248;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 422);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRecipe.ResumeLayout(false);
            this.tabPageIngredientGroup.ResumeLayout(false);
            this.tabPageIngredientGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRecipe;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView vlRevipeSteps;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvIngredientsRecipe;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPageIngredientGroup;
        private System.Windows.Forms.ListView lvIngredient;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnEditIngr;
        private System.Windows.Forms.Button btnDeleteIngr;
        private System.Windows.Forms.Button btnAddIngr;
        private System.Windows.Forms.TextBox txtNameIngr;
        private System.Windows.Forms.TextBox txtNameGrou;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditGrou;
        private System.Windows.Forms.Button btnDeleteGrou;
        private System.Windows.Forms.Button btnAddGrou;
        private System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

