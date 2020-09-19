using System;
using System.Reflection;

namespace ParagonaSky.Extensions.WinForms.Editor.Internal
{
    internal struct ObjectProperty<TAttribute> where TAttribute : Attribute
    {
        public readonly TAttribute Attribute;

        public readonly PropertyInfo PropertyInfo;

        public ObjectProperty(PropertyInfo propertyInfo)
        {
            Attribute = propertyInfo.GetCustomAttribute<TAttribute>();
            PropertyInfo = propertyInfo;
        }
    }
}
