using System;
using System.Reflection;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor.Internal
{
    internal struct EditorBindedField
    {
        public readonly FieldInfo EditorField;
        public readonly ObjectProperty<ControlPropertyAttribute> ObjectProperty;

        public EditorBindedField(FieldInfo editorField, ObjectProperty<ControlPropertyAttribute> objectProperty)
        {
            if (editorField.Name != objectProperty.Attribute.ControlName)
                throw new InvalidOperationException("Editor field and object property have different names");

            EditorField = editorField;
            ObjectProperty = objectProperty;
        }

        public void SetToEditorField(Form editor, object @object)
        {
            var objectValue = ObjectProperty.PropertyInfo.GetValue(@object);

            if (ObjectProperty.Attribute.ValueConverter != default)
                objectValue = ObjectProperty.Attribute.ValueConverter.Convert(objectValue);

            EditorField.SetValue(editor, objectValue);
        }

        public void SetToObjectProperty(Form editor, object @object)
        {
            object editorValue;

            if (ObjectProperty.Attribute.IsProperty) editorValue = ObjectProperty.Attribute.PropertyInfo.GetValue(editor);
            else editorValue = ObjectProperty.Attribute.FieldInfo.GetValue(editor);

            if (ObjectProperty.Attribute.ValueConverter != default)
                editorValue = ObjectProperty.Attribute.ValueConverter.ConvertBack(editorValue);

            ObjectProperty.PropertyInfo.SetValue(@object, editorValue);
        }
    }
}
