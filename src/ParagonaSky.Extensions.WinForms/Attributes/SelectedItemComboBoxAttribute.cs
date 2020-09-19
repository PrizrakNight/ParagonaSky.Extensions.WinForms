using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class SelectedItemComboBoxAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public SelectedItemComboBoxAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(ComboBox).GetProperty(nameof(ComboBox.SelectedItem));
        }
    }
}
