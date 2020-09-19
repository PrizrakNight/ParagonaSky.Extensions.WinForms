using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor
{
    public interface IEditor<TObject> where TObject : class
    {
        object EditableObject { get; set; }

        Form Editor { get; set; }

        IEditor<TObject> OnSuccess(Action<TObject> onSuccess);
        IEditor<TObject> OnFailed(Action<Exception> onFailed);
        IEditor<TObject> OnModelInvalid(Action<ICollection<ValidationResult>> onModelInvalid);

        DialogResult Open();
    }
}
