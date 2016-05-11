using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzyLogic.Mamdani;
using FuzzyLogic.Mamdani.Problems;

namespace Forms
{
    public partial class MainForm : Form
    {
        private readonly ProblemConditions _problemConditions;

        public MainForm()
        {
            _problemConditions = new ProblemConditions();
            InitializeComponent();
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
            if (_problemConditions.Variables.ContainsKey(variableName))
                return false;

            _problemConditions.Variables.Add(variableName, new LingVariable(variableName, terms));
            return true;
        }

        private void RefreshVariablesListView()
        {
            var values = _problemConditions.Variables.Values.Select(x => x.ToStringArray());
            RefreshListView(variablesListView, values);
        }

        private void RefreshListView(ListView listView, IEnumerable<string[]> values)
        {
            var listViewItems = values.Select(x => new ListViewItem(x)).ToArray();
            listView.Items.Clear();
            listView.Items.AddRange(listViewItems);
        }

        private void deleteVariable_Click(object sender, EventArgs e)
        {
            var values = _problemConditions.Variables.Values.Select(x => x.Name).ToArray();
            var deleteValueForm = new DeleteValueForm(values);
            deleteValueForm.OnDeleteItem += DeleteVariable;
            deleteValueForm.ShowDialog();

            RefreshVariablesListView();
        }

        private void DeleteVariable(string name)
        {
            if (_problemConditions.Variables.ContainsKey(name))
                _problemConditions.Variables.Remove(name);
        }
    }
}
