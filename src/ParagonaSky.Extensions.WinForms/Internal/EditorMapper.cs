using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor.Internal
{
    internal static class EditorMapper
    {
        private static readonly List<EditorGraph> _mapHistory = new List<EditorGraph>();

        public static void MapToEditor(Form editor, object @object)
        {
            GetOrAddHistory(editor, @object).SetValuesToEditor();
        }

        public static void MapFromEditor(Form editor, object @object)
        {
            GetOrAddHistory(editor, @object).SetValuesToObject();
        }

        private static EditorGraph GetOrAddHistory(Form editor, object @object)
        {
            var history = _mapHistory.SingleOrDefault(mh => mh.Object == @object);

            if (EditorGraph.IsNull(history))
            {
                history = new EditorGraph(editor, new ObjectGraph<ControlPropertyAttribute>(@object));

                _mapHistory.Add(history);
            }

            return history;
        }
    }
}
