using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public class DateTimePickerAttribute : ControlPropertyAttribute
    {
        internal override bool IsProperty => true;

        public DateTimePickerAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(DateTimePicker).GetProperty(nameof(DateTimePicker.Value));
        }
    }
}
