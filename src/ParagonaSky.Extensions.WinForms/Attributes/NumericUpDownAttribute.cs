using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class NumericUpDownAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public NumericUpDownAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(NumericUpDown).GetProperty(nameof(NumericUpDown.Value));
        }
    }
}
