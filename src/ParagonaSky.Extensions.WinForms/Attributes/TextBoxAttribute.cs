using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class TextBoxAttribute : ControlPropertyAttribute
    {
        protected override bool IsProperty => true;

        public TextBoxAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(TextBox).GetProperty(nameof(TextBox.Text));
        }
    }
}
