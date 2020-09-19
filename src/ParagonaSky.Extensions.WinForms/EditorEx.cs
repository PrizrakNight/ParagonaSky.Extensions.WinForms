using ParagonaSky.Extensions.WinForms.Editor.Internal;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public static class EditorEx
    {
        public static IEditor<TObject> EditUsing<TObject, TEditor>(this TObject @object)
            where TObject : class
            where TEditor : Form, new()
        {
            return new StandardEditor<TObject>(@object, new TEditor());
        }
    }
}
