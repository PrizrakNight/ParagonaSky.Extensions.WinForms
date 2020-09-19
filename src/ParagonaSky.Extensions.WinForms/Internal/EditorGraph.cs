using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor.Internal
{
    internal struct EditorGraph
    {
        public readonly object Object;

        public readonly Form Editor;

        public readonly EditorBindedField[] BindedFields;

        public EditorGraph(Form editor, ObjectGraph<ControlPropertyAttribute> objectGraph)
        {
            Editor = editor;
            Object = objectGraph.Object;
            BindedFields = default;

            BindedFields = FindBindedFields(objectGraph).ToArray();
        }

        public static bool IsNull(EditorGraph editorGraph)
        {
            return editorGraph.Object == default && editorGraph.Editor == default && editorGraph.BindedFields == default;
        }

        public void SetValuesToEditor()
        {
            for (int i = 0; i < BindedFields.Length; i++)
                BindedFields[i].SetToEditorField(Editor, Object);
        }

        public void SetValuesToObject()
        {
            for (int i = 0; i < BindedFields.Length; i++)
                BindedFields[i].SetToObjectProperty(Editor, Object);
        }

        private IEnumerable<EditorBindedField> FindBindedFields(ObjectGraph<ControlPropertyAttribute> objectGraph)
        {
            var editorType = Editor.GetType();

            for (int i = 0; i < objectGraph.Properties.Length; i++)
            {
                var currentProperty = objectGraph.Properties[i];
                var editorField = editorType.GetField(currentProperty.Attribute.ControlName, BindingFlags.NonPublic | BindingFlags.Instance);

                if (editorField != default)
                    yield return new EditorBindedField(editorField, currentProperty);
            }
        }
    }
}
