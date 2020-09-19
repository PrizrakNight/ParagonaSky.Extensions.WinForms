using System;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor.Attributes
{
    public class DateTimePickerAttribute : ControlPropertyAttribute
    {
        protected override bool IsProperty => true;

        public DateTimePickerAttribute(string controlName, Type converterType = null) : base(controlName, converterType)
        {
            PropertyInfo = typeof(DateTimePicker).GetProperty(nameof(DateTimePicker.Value));
        }
    }
}
