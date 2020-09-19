using System;
using System.Linq;
using System.Reflection;

namespace ParagonaSky.Extensions.WinForms.Editor.Internal
{
    internal struct ObjectGraph<TAttribute> where TAttribute : Attribute
    {
        public readonly object Object;

        public readonly ObjectProperty<TAttribute>[] Properties;

        public ObjectGraph(object @object)
        {
            Object = @object;

            Properties = @object.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(property => new ObjectProperty<TAttribute>(property))
                .Where(oProperty => oProperty.Attribute != default)
                .ToArray();
        }

        public override bool Equals(object obj)
        {
            if (obj is ObjectGraph<TAttribute> otherGrapth)
                return otherGrapth.Object == Object;

            return false;
        }

        public override int GetHashCode() => Object.GetHashCode();
    }
}
