using System;
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
                if (!double.TryParse(s, out value))
                {
                    throw new ArgumentException("Не корректно заполнены входные данные");
                }
                list.Add(value);
            }
            return list.ToArray();
        }

        private void problemSample1_Click(object sender, EventArgs e)
        {
            var problem = ProblemSamples.First();

            Variables.Clear();
            Variables.AddRange(problem.ProblemConditions.Variables);

            Rules.Clear();
            Rules.AddRange(problem.ProblemConditions.Rules);

            inputDataTextBox.Text = string.Join(";", problem.InputData);

            RefreshVariablesListView();
            RefreshRulesListView();
        }
    }
}
