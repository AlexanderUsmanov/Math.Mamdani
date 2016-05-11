﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzyLogic.Mamdani;
using FuzzyLogic.Mamdani.Statements;

namespace Forms
{
    public partial class AddRuleForm : Form
    {
        private readonly List<Condition> _conditions;
        private Conclusion _conclusion;

        private List<string> UsedVariableNames
        {
            get
            {
                var names = _conditions.Select(x => x.LingVariable.Name).ToList();
                if(_conclusion != null)
                    names.Add(_conclusion.LingVariable.Name);
                return names;
            }
        }

        private readonly List<LingVariable> _variables;
         
        public AddRuleForm(List<LingVariable> variables)
        {
            _variables = variables;

            _conditions = new List<Condition>();
            InitializeComponent();
        }

        private void addCondition_Click(object sender, System.EventArgs e)
        {
            var variablesForRuleStatement = _variables.Where(x => !UsedVariableNames.Contains(x.Name)).ToList();
            var addConditionForm = new AddRuleStatementForm(variablesForRuleStatement);
            addConditionForm.OnAddStatement += AddCondition;
            addConditionForm.ShowDialog();

        }

        private void AddCondition(string variableName, string termName)
        {
            var variable = _variables.FirstOrDefault(x => x.Name == variableName);
            var term = variable.Terms.FirstOrDefault(x => x.Name == termName);

            var condition = new Condition(variable, term);
            _conditions.Add(condition);
        }

        private void deleteCondition_Click(object sender, System.EventArgs e)
        {
            var deleteConditionForm = new DeleteValueForm(_conditions.Select(c => c.LingVariable.Name).ToArray());
            deleteConditionForm.OnDeleteItem += DeleteCondition;
            deleteConditionForm.ShowDialog();
        }

        private void DeleteCondition(string variableName)
        {
            var condition = _conditions.FirstOrDefault(x => x.LingVariable.Name == variableName);
            if (condition != null)
                _conditions.Remove(condition);
        }

        private void addConclusion_Click(object sender, System.EventArgs e)
        {
            if (_conclusion != null)
            {
                MessageBox.Show("Можно заполнить только одно заключение", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var variablesForRuleStatement = _variables.Where(x => !UsedVariableNames.Contains(x.Name)).ToList();
            var addConditionForm = new AddRuleStatementForm(variablesForRuleStatement);
            addConditionForm.OnAddStatement += AddConclusion;
            addConditionForm.ShowDialog();
        }

        private void AddConclusion(string variableName, string termName)
        {
            var variable = _variables.FirstOrDefault(x => x.Name == variableName);
            var term = variable.Terms.FirstOrDefault(x => x.Name == termName);

            _conclusion = new Conclusion(variable, term);
        }

        private void deleteConclusion_Click(object sender, System.EventArgs e)
        {
            if (_conclusion == null)
            {
                MessageBox.Show("Заключение можно удалить только после заполнения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _conclusion = null;
        }

        public delegate void AddRuleDelegate(List<Condition> conditions, Conclusion conclusion);
        public event AddRuleDelegate OnAddRule;

        private void save_Click(object sender, System.EventArgs e)
        {
            var closeWindow = true;
            if (OnAddRule != null)
            {
                if (_conditions.Count < _variables.Count - 1)
                {
                    MessageBox.Show("Количество условий в правиле должно быть на 1 меньше числа переменных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeWindow = false;
                }

                if (_conclusion == null)
                {
                    MessageBox.Show("Не возможно создать правило без заключения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeWindow = false;
                }

                if (closeWindow)
                {
                    OnAddRule(_conditions, _conclusion);
                }
            }

            if (closeWindow)
                Close();
        }
    }
}