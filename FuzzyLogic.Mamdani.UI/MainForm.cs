﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzyLogic.Mamdani;
using FuzzyLogic.Mamdani.Interfaces;
using FuzzyLogic.Mamdani.Problems;
using FuzzyLogic.Mamdani.Statements;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly List<LingVariable> Variables = new List<LingVariable>();
        private readonly List<Rule> Rules = new List<Rule>();

        private readonly IMamdaniService _mamdaniService;

        public MainForm(IMamdaniService mamdaniService)
        {
            _mamdaniService = mamdaniService;
            InitializeComponent();
        }


        private void RefreshListView(ListView listView, IEnumerable<string[]> values)
        {
            var listViewItems = values.Select(x => new ListViewItem(x)).ToArray();
            listView.Items.Clear();
            listView.Items.AddRange(listViewItems);
        }

        private void RefreshVariablesListView()
        {
            var values = Variables.Select(x => x.ToStringArray());
            RefreshListView(variablesListView, values);
        }

        private void RefreshRulesListView()
        {
            var rules = Rules.Select(x => x.ToStringArray());
            RefreshListView(rulesListView, rules);
        }





        private void addVariable_Click(object sender, EventArgs e)
        {
            var addVariableForm = new AddVariableForm();
            addVariableForm.OnAddVariable += AddVariable;
            addVariableForm.ShowDialog();

            RefreshVariablesListView();
        }

        private bool AddVariable(string variableName, List<Term> terms)
        {
            if (Variables.Any(x => x.Name == variableName))
                return false;

            Variables.Add(new LingVariable(variableName, terms));
            return true;
        }



        private void deleteVariable_Click(object sender, EventArgs e)
        {
            var values = Variables.Select(x => x.Name).ToArray();
            var deleteValueForm = new DeleteValueForm(values);
            deleteValueForm.OnDeleteItem += DeleteVariable;
            deleteValueForm.ShowDialog();

            RefreshVariablesListView();
        }

        private void DeleteVariable(string name)
        {
            var variable = Variables.FirstOrDefault(x => x.Name == name);
            if (variable != null)
                Variables.Remove(variable);
        }

        





        private void addRule_Click(object sender, EventArgs e)
        {
            var addRuleForm = new AddRuleForm(Variables);
            addRuleForm.OnAddRule += AddRule;
            addRuleForm.ShowDialog();

            RefreshRulesListView();
        }

        private void AddRule(List<Condition> conditions, Conclusion conclusion)
        {
            var rule = new Rule(conditions, conclusion);
            Rules.Add(rule);
        }



        private void deleteRule_Click(object sender, EventArgs e)
        {
            var values = Rules.Select(x => string.Join(",", x.ToStringArray())).ToArray();
            var deleteValueForm = new DeleteValueForm(values);
            deleteValueForm.OnDeleteItem += DeleteRule;
            deleteValueForm.ShowDialog();

            RefreshRulesListView();
        }

        private void DeleteRule(string ruleString)
        {
            var rule = Rules.FirstOrDefault(x => string.Join(",", x.ToStringArray()) == ruleString);
            if (rule != null)
                Rules.Remove(rule);
        }

        private void solveProblem_Click(object sender, EventArgs e)
        {
            try
            {
                var inputData = GetInputData();

                if (inputData.Length != Variables.Count - 1)
                {
                    throw new ArgumentException($"Некорректное число входных параметров. {inputData.Length} вместо ожидаемых {Variables.Count - 1}");
                }

                ProblemConditions conditions = new ProblemConditions();
                foreach (var lingVariable in Variables)
                {
                    conditions.AddVariable(lingVariable);
                }

                foreach (var rule in Rules)
                {
                    conditions.AddRule(rule);
                }

                var problem = new Problem()
                {
                    InputData = inputData,
                    ProblemConditions = conditions
                };

                var result = _mamdaniService.SolveProblem(problem);
                if (double.IsNaN(result) || double.IsInfinity(result))
                    resultTextBox.Text = "Не удалось вычислить значение.";
                resultTextBox.Text = result.ToString();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double[] GetInputData()
        {
            var str = inputDataTextBox.Text;
            var strs = str.Split(';');

            var list = new List<double>();
            foreach (var s in strs)
            {
                double value;
                if (!double.TryParse(s.Replace(".", ","), out value))
                {
                    throw new ArgumentException("Не корректно заполнены входные данные");
                }
                list.Add(value);
            }
            return list.ToArray();
        }

        private void задача2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = ProblemSamples.ReadConditionsFromXmlString(Resources.input2);

            if (!result.Success)
            {
                MessageBox.Show("Во время загрузки задачи возникли непридвиденные ошибки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Variables.Clear();
            Variables.AddRange(result.Data.Variables);

            Rules.Clear();
            Rules.AddRange(result.Data.Rules);

            inputDataTextBox.Text = "0.8;0.97;0.58;0.75;0.95";

            RefreshVariablesListView();
            RefreshRulesListView();
        }

        private void задача3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = ProblemSamples.ReadConditionsFromXmlString(Resources.input3);

            if (!result.Success)
            {
                MessageBox.Show("Во время загрузки задачи возникли непридвиденные ошибки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Variables.Clear();
            Variables.AddRange(result.Data.Variables);

            Rules.Clear();
            Rules.AddRange(result.Data.Rules);

            inputDataTextBox.Text = "0.8;0.68";

            RefreshVariablesListView();
            RefreshRulesListView();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Файлы xml|*.xml";
            ofd.Multiselect = false;

            var dialogResult = ofd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using (var stream = ofd.OpenFile())
                {
                    var result = ProblemSamples.ReadConditionsFromXmlStream(stream);

                    if (!result.Success)
                    {
                        MessageBox.Show("Во время загрузки задачи возникли непридвиденные ошибки", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Variables.Clear();
                    Variables.AddRange(result.Data.Variables);

                    Rules.Clear();
                    Rules.AddRange(result.Data.Rules);

                    inputDataTextBox.Text = "";

                    RefreshVariablesListView();
                    RefreshRulesListView();
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Файлы xml|*.xml";
            var dialogResult = sfd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var filePath = sfd.FileName;
                var conditions = new ProblemConditions(Variables, Rules);
                ProblemSamples.WriteToFile(conditions, filePath);
            }
        }
    }
}
