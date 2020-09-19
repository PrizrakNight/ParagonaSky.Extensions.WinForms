using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class ComboBoxAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public ComboBoxAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(ComboBox).GetProperty(nameof(ComboBox.DataSource));
        }
    }
}
