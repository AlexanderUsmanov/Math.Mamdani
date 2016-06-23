using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class AddVariableValueForm : Form
    {
        private bool _closeWindow;
        public AddVariableValueForm()
        {
            InitializeComponent();
            pictureBox1.Image = Resources.TrapFuncDescription;
        }

        public delegate bool AddVariableValueDelegate(string name, double a, double b, double c, double d);

        public event AddVariableValueDelegate OnAddVariableValue;

        private void addButton_Click(object sender, EventArgs e)
        {
            _closeWindow = true;

            if (OnAddVariableValue != null)
            {
                try
                {
                    var result = OnAddVariableValue.Invoke(name.Text, GetDoubleValue(a), GetDoubleValue(b), GetDoubleValue(c), GetDoubleValue(d));
                    if (!result)
                    {
                        MessageBox.Show("Такое текстовое значение уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _closeWindow = false;
                    }
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _closeWindow = false;
                }
            }

            if (_closeWindow)
                this.Close();
        }

        private double GetDoubleValue(TextBox textBox)
        {
            var text = textBox.Text;
            double value;
            if (!double.TryParse(text, out value))
            {
                _closeWindow = false;
                throw new ArgumentException($"Не корректное значение в поле {textBox.Name}");
            }
            return value;
        }
    }
}
