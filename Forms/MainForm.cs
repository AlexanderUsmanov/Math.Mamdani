using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzyLogic.Mamdani;
using FuzzyLogic.Mamdani.Statements;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly List<LingVariable> Variables = new List<LingVariable>();
        private readonly List<Rule> Rules = new List<Rule>(); 
        

        public MainForm()
        {
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
    }
}
