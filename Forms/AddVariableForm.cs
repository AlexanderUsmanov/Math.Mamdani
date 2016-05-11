using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzyLogic.Mamdani;

namespace Forms
{
    public partial class AddVariableForm : Form
    {
        private List<Term> _terms = new List<Term>();
        public AddVariableForm()
        {
            InitializeComponent();
        }

        private void RefreshFormListView()
        {
            var values = _terms.Select(x => x.ToStringArray());
            RefreshListView(listView1, values);
        }

        public void RefreshListView(ListView listView, IEnumerable<string[]> values)
        {
            var listViewItems = values.Select(x => new ListViewItem(x)).ToArray();
            listView.Items.Clear();
            listView.Items.AddRange(listViewItems);
        }



        private void addValue_Click(object sender, System.EventArgs e)
        {
            var addVariableValueForm = new AddVariableValueForm();
            addVariableValueForm.OnAddVariableValue += AddValue;
            addVariableValueForm.ShowDialog();

            RefreshFormListView();
        }

        private bool AddValue(string name, double a, double b, double c, double d)
        {
            if (_terms.Any(x => x.Name == name))
                return false;
            _terms.Add(new Term(name, a, b, c, d));
            return true;
        }




        private void deleteValue_Click(object sender, System.EventArgs e)
        {
            var values = _terms.Select(x => x.Name).ToArray();
            var deleteValueForm = new DeleteValueForm(values);
            deleteValueForm.OnDeleteItem += DeleteValue;
            deleteValueForm.ShowDialog();

            RefreshFormListView();
        }

        private void DeleteValue(string name)
        {
            var value = _terms.FirstOrDefault(x => x.Name == name);
            if (value != null)
                _terms.Remove(value);
        }



        public delegate bool AddVariableDelegate(string name, List<Term> terms);

        public event AddVariableDelegate OnAddVariable;

        private void addVariable_Click(object sender, System.EventArgs e)
        {
            var closeWindow = true;
            if (string.IsNullOrWhiteSpace(variableName.Text))
            {
                MessageBox.Show("Нужно задать имя переменной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeWindow = false;
            }

            var name = variableName.Text;
            if (OnAddVariable != null)
            {
                var result = OnAddVariable(name, _terms);
                if (!result)
                {
                    closeWindow = false;
                }
            }

            if (closeWindow)
                Close();
        }
    }
}
