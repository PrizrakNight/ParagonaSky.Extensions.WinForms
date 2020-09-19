using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    class SelectedItemListBoxAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public SelectedItemListBoxAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(ListBox).GetProperty(nameof(ListBox.SelectedItem));
        }
    }
}
