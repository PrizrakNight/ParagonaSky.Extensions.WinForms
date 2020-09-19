using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class ListBoxAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public ListBoxAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(ListBox).GetProperty(nameof(ListBox.DataSource));
        }
    }
}
