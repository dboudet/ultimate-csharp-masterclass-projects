using System.Numerics;

namespace NumericTypeSuggesterWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool IsInputComplete()
        {
            return
                MinValueInput.Text.Length > 0 &&
                MaxValueInput.Text.Length > 0 &&
                MinValueInput.Text != "-" &&
                MaxValueInput.Text != "-";
        }

        public void InvalidateMaxValueInput()
        {
            if (IsInputComplete())
            {
                bool isValid =
                    BigInteger.Parse(MaxValueInput.Text) > BigInteger.Parse(MinValueInput.Text);

                MaxValueInput.BackColor = isValid ? default : Color.IndianRed;

            }
        }

        public bool IntegralOnly { get; set; } = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IntegralOnly = !IntegralOnly;
            PreciseCheckbox.Visible = !IntegralOnlyCheckbox.Checked;
            UpdateSuggestedType();
        }

        public bool NeedsPrecise { get; set; }
        private void PreciseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            NeedsPrecise = !NeedsPrecise;
            UpdateSuggestedType();
        }

        public void UpdateSuggestedType()
        {
            SuggestedTypeOutput.Text = SuggestedTypeText();
        }

        private void TextBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!IsValidInput(e.KeyChar, textBox))
            {
                e.Handled = true;
            }
        }

        private bool IsValidInput(char keyChar, TextBox textBox)
        {
            return char.IsControl(keyChar)
                || char.IsDigit(keyChar)
                || (keyChar == '-' && textBox.SelectionStart == 0);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            InvalidateMaxValueInput();
            UpdateSuggestedType();
        }

        public string SuggestedTypeText()
        {
            if (!IsInputComplete())
            {
                return string.Empty;
            }
            var min = BigInteger.Parse(MinValueInput.Text);
            var max = BigInteger.Parse(MaxValueInput.Text);
            switch (true)
            {
                case bool when min >= 0 && max <= byte.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "byte";
                case bool when min >= sbyte.MinValue && max <= sbyte.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "sbyte";
                case bool when min >= 0 && max <= ushort.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "ushort";
                case bool when min >= short.MinValue && max <= short.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "short";
                case bool when min >= 0 && max <= int.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "uint";
                case bool when min >= int.MinValue && max <= int.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "int";
                case bool when min >= 0 && max <= ulong.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "ulong";
                case bool when min >= long.MinValue && max <= long.MaxValue && IntegralOnly && !NeedsPrecise:
                    return "long";
                case bool when (min < long.MinValue || max > long.MaxValue) && IntegralOnly && !NeedsPrecise:
                    return "BigInteger";
                case bool when min >= (BigInteger)float.MinValue && max <= (BigInteger)float.MaxValue && !IntegralOnly && !NeedsPrecise:
                    return "float";
                case bool when min >= (BigInteger)double.MinValue && max <= (BigInteger)double.MaxValue && !IntegralOnly && !NeedsPrecise:
                    return "double";
                case bool when NeedsPrecise && max <= (BigInteger)decimal.MaxValue:
                    return "decimal";
                default:
                    return "Impossible representation";
            }
        }

    }
}
