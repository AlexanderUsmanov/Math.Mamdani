namespace Forms
{
    partial class MainForm
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
            this.variablesListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteVariable = new System.Windows.Forms.Button();
            this.addVariable = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteRule = new System.Windows.Forms.Button();
            this.addRule = new System.Windows.Forms.Button();
            this.rulesListView = new System.Windows.Forms.ListView();
            this.conditions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conclusion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.solveProblem = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.values = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // variablesListView
            // 
            this.variablesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.values});
            this.variablesListView.GridLines = true;
            this.variablesListView.Location = new System.Drawing.Point(6, 19);
            this.variablesListView.Name = "variablesListView";
            this.variablesListView.Size = new System.Drawing.Size(262, 120);
            this.variablesListView.TabIndex = 1;
            this.variablesListView.UseCompatibleStateImageBehavior = false;
            this.variablesListView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Имя переменной";
            this.name.Width = 104;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteVariable);
            this.groupBox1.Controls.Add(this.addVariable);
            this.groupBox1.Controls.Add(this.variablesListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 183);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Переменные";
            // 
            // deleteVariable
            // 
            this.deleteVariable.Location = new System.Drawing.Point(143, 145);
            this.deleteVariable.Name = "deleteVariable";
            this.deleteVariable.Size = new System.Drawing.Size(125, 23);
            this.deleteVariable.TabIndex = 3;
            this.deleteVariable.Text = "Удалить";
            this.deleteVariable.UseVisualStyleBackColor = true;
            this.deleteVariable.Click += new System.EventHandler(this.deleteVariable_Click);
            // 
            // addVariable
            // 
            this.addVariable.Location = new System.Drawing.Point(6, 145);
            this.addVariable.Name = "addVariable";
            this.addVariable.Size = new System.Drawing.Size(131, 23);
            this.addVariable.TabIndex = 2;
            this.addVariable.Text = "Добавить";
            this.addVariable.UseVisualStyleBackColor = true;
            this.addVariable.Click += new System.EventHandler(this.addVariable_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteRule);
            this.groupBox2.Controls.Add(this.addRule);
            this.groupBox2.Controls.Add(this.rulesListView);
            this.groupBox2.Location = new System.Drawing.Point(292, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 182);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Правила вывода";
            // 
            // deleteRule
            // 
            this.deleteRule.Location = new System.Drawing.Point(140, 144);
            this.deleteRule.Name = "deleteRule";
            this.deleteRule.Size = new System.Drawing.Size(115, 23);
            this.deleteRule.TabIndex = 2;
            this.deleteRule.Text = "Удалить";
            this.deleteRule.UseVisualStyleBackColor = true;
            // 
            // addRule
            // 
            this.addRule.Location = new System.Drawing.Point(6, 144);
            this.addRule.Name = "addRule";
            this.addRule.Size = new System.Drawing.Size(128, 23);
            this.addRule.TabIndex = 1;
            this.addRule.Text = "Добавить";
            this.addRule.UseVisualStyleBackColor = true;
            // 
            // rulesListView
            // 
            this.rulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.conditions,
            this.conclusion});
            this.rulesListView.GridLines = true;
            this.rulesListView.Location = new System.Drawing.Point(6, 18);
            this.rulesListView.Name = "rulesListView";
            this.rulesListView.Size = new System.Drawing.Size(249, 120);
            this.rulesListView.TabIndex = 0;
            this.rulesListView.UseCompatibleStateImageBehavior = false;
            this.rulesListView.View = System.Windows.Forms.View.Details;
            // 
            // conditions
            // 
            this.conditions.Text = "Условия";
            this.conditions.Width = 179;
            // 
            // conclusion
            // 
            this.conclusion.Text = "Результат";
            this.conclusion.Width = 66;
            // 
            // solveProblem
            // 
            this.solveProblem.Location = new System.Drawing.Point(12, 201);
            this.solveProblem.Name = "solveProblem";
            this.solveProblem.Size = new System.Drawing.Size(218, 23);
            this.solveProblem.TabIndex = 4;
            this.solveProblem.Text = "Запустить решение задачи";
            this.solveProblem.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(298, 208);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(59, 13);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "Результат";
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultTextBox.Location = new System.Drawing.Point(385, 205);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(162, 20);
            this.resultTextBox.TabIndex = 6;
            // 
            // values
            // 
            this.values.Text = "Значения";
            this.values.Width = 129;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 233);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.solveProblem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Алгоритм Мамдани";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView variablesListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteVariable;
        private System.Windows.Forms.Button addVariable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteRule;
        private System.Windows.Forms.Button addRule;
        private System.Windows.Forms.ListView rulesListView;
        private System.Windows.Forms.ColumnHeader conditions;
        private System.Windows.Forms.ColumnHeader conclusion;
        private System.Windows.Forms.Button solveProblem;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.ColumnHeader values;
    }
}

