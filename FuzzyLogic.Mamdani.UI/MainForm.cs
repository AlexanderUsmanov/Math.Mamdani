using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzyLogic.Mamdani;
using FuzzyLogic.Mamdani.Interfaces;
using FuzzyLogic.Mamdani.Problems;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly List<LingVariable> _variables = new List<LingVariable>();
        private readonly List<Rule> _rules = new List<Rule>();

        private readonly IMamdaniService _mamdaniService;

        public MainForm(IMamdaniService mamdaniService)
        {
            _mamdaniService = mamdaniService;
            InitializeComponent();
        }

        #region private
        private void RefreshListView(ListView listView, IEnumerable<string[]> values)
        {
            var listViewItems = values.Select(x => new ListViewItem(x)).ToArray();
            listView.Items.Clear();
            listView.Items.AddRange(listViewItems);
        }

        private void RefreshVariablesListView()
        {
            var values = _variables.Select(x => x.ToStringArray());
            RefreshListView(variablesListView, values);
        }

        private void RefreshRulesListView()
        {
            var rules = _rules.Select(x => x.ToStringArray());
            RefreshListView(rulesListView, rules);
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
        #endregion

        #region Events
        private void addVariable_Click(object sender, EventArgs e)
        {
            var addVariableForm = new EditVariableForm();
            addVariableForm.OnSaveVariable += (variableName, terms) =>
            {
                if (_variables.Any(x => x.Name == variableName))
                    return false;

                _variables.Add(new LingVariable(variableName, terms));
                return true;
            };
            addVariableForm.ShowDialog();

            RefreshVariablesListView();
        }

        private void deleteVariable_Click(object sender, EventArgs e)
        {
            var values = _variables.Select(x => x.Name).ToArray();
            var deleteValueForm = new DeleteValueForm(values);
            deleteValueForm.OnDeleteItem += (s) =>
            {
                var variable = this._variables.FirstOrDefault(x => x.Name == s);
                if (variable != null)
                    this._variables.Remove(variable);
            };
            deleteValueForm.ShowDialog();

            RefreshVariablesListView();
        }

        private void editVariable_Click(object sender, EventArgs e)
        {
            var variableViewItem = variablesListView.SelectedItems[0];
            var variable = _variables[variableViewItem.Index];

            var editVariableForm = new EditVariableForm(variable);
            editVariableForm.OnSaveVariable += (variableName, terms) =>
            {
                if (terms.Count == 0)
                    return false;
                foreach (var term in terms)
                {
                    var localTerm = variable.Terms.FirstOrDefault(x => x.Name == term.Name);
                    if (!localTerm.AccessoryFunc.IsEqual(term.AccessoryFunc))
                        localTerm.AccessoryFunc = term.AccessoryFunc.CopyFunc();
                }
                return true;
            };
            editVariableForm.ShowDialog();

            RefreshVariablesListView();
        }

        private void addRule_Click(object sender, EventArgs e)
        {
            var addRuleForm = new EditRuleForm(_variables);
            addRuleForm.OnAddRule += (conditions, conclusion) =>
            {
                var rule = new Rule(conditions, conclusion);
                _rules.Add(rule);
            };
            addRuleForm.ShowDialog();

            RefreshRulesListView();
        }

        private void deleteRule_Click(object sender, EventArgs e)
        {
            var values = _rules.Select(x => string.Join(",", x.ToStringArray())).ToArray();
            var deleteValueForm = new DeleteValueForm(values);
            deleteValueForm.OnDeleteItem += (ruleString) =>
            {
                var rule = _rules.FirstOrDefault(x => string.Join(",", x.ToStringArray()) == ruleString);
                if (rule != null)
                    _rules.Remove(rule);
            };
            deleteValueForm.ShowDialog();

            RefreshRulesListView();
        }

        private void editRule_Click(object sender, EventArgs e)
        {
            var ruleViewItem = rulesListView.SelectedItems[0];
            var rule = _rules[ruleViewItem.Index];

            var editRuleForm = new EditRuleForm(_variables, rule);
            editRuleForm.ShowDialog();

            RefreshRulesListView();
        }

        private void solveProblem_Click(object sender, EventArgs e)
        {
            try
            {
                var inputData = GetInputData();

                if (inputData.Length != _variables.Count - 1)
                {
                    throw new ArgumentException($"Некорректное число входных параметров. {inputData.Length} вместо ожидаемых {_variables.Count - 1}");
                }

                ProblemConditions conditions = new ProblemConditions();
                foreach (var lingVariable in _variables)
                {
                    conditions.AddVariable(lingVariable);
                }

                foreach (var rule in _rules)
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

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = ProblemSamples.ReadConditionsFromXmlString(Resources.input2);

            if (!result.Success)
            {
                MessageBox.Show("Во время загрузки задачи возникли непридвиденные ошибки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _variables.Clear();
            _variables.AddRange(result.Data.Variables);

            _rules.Clear();
            _rules.AddRange(result.Data.Rules);

            inputDataTextBox.Text = "0.8;0.97;0.58;0.75;0.95";

            RefreshVariablesListView();
            RefreshRulesListView();
        }

        private void task3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = ProblemSamples.ReadConditionsFromXmlString(Resources.input3);

            if (!result.Success)
            {
                MessageBox.Show("Во время загрузки задачи возникли непридвиденные ошибки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _variables.Clear();
            _variables.AddRange(result.Data.Variables);

            _rules.Clear();
            _rules.AddRange(result.Data.Rules);

            inputDataTextBox.Text = "0.8;0.68";

            RefreshVariablesListView();
            RefreshRulesListView();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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

                    _variables.Clear();
                    _variables.AddRange(result.Data.Variables);

                    _rules.Clear();
                    _rules.AddRange(result.Data.Rules);

                    inputDataTextBox.Text = "";

                    RefreshVariablesListView();
                    RefreshRulesListView();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Файлы xml|*.xml";
            var dialogResult = sfd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var filePath = sfd.FileName;
                var conditions = new ProblemConditions(_variables, _rules);
                ProblemSamples.WriteToFile(conditions, filePath);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Вы уверены что хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if(dialogResult == DialogResult.Yes)
                this.Close();
        }
        #endregion

        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = ProblemSamples.ReadConditionsFromXmlString(Resources.input1);

            if (!result.Success)
            {
                MessageBox.Show("Во время загрузки задачи возникли непридвиденные ошибки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _variables.Clear();
            _variables.AddRange(result.Data.Variables);

            _rules.Clear();
            _rules.AddRange(result.Data.Rules);

            inputDataTextBox.Text = "";

            RefreshVariablesListView();
            RefreshRulesListView();
        }
    }
}
