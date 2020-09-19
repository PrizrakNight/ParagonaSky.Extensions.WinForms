using System;
using System.Reflection;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ControlPropertyAttribute : Attribute
    {
        public readonly string ControlName;

        public readonly IValueConverter ValueConverter;

        internal abstract bool IsProperty { get; }

        internal PropertyInfo PropertyInfo;
        internal FieldInfo FieldInfo;

        protected ControlPropertyAttribute(string controlName, Type converterType = default)
        {
            ControlName = controlName;

            if (converterType != default)
                ValueConverter = (IValueConverter)Activator.CreateInstance(converterType);
        }

        public object GetValue(object control)
        {
            object value;

            if (IsProperty) value = PropertyInfo.GetValue(control);
            else value = FieldInfo.GetValue(control);

            if (ValueConverter != default)
                value = ValueConverter.Convert(value);

            return value;
        }

        public void SetValue(object control, object value)
        {
            value = ValueConverter != default ? ValueConverter.ConvertBack(value) : value;

            if (IsProperty) PropertyInfo.SetValue(control, value);
            else FieldInfo.SetValue(control, value);
        }
    }
}
