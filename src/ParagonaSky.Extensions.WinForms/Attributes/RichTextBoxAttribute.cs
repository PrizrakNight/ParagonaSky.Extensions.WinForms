using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class RichTextBoxAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public RichTextBoxAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(RichTextBox).GetProperty(nameof(RichTextBox.Text));
        }
    }
}
