using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace ParagonaSky.Extensions.WinForms.Editor.Internal
{
    internal class StandardEditor<TObject> : IEditor<TObject> where TObject : class
    {
        public object EditableObject { get; set; }

        public Form Editor { get; set; }

        private Action<Exception> _onFailed;
        private Action<ICollection<ValidationResult>> _onModelInvalid;
        private Action<TObject> _onSuccess;

        public StandardEditor(object editableObject, Form editor)
        {
            EditableObject = editableObject;
            Editor = editor;
        }

        public IEditor<TObject> OnFailed(Action<Exception> onFailed)
        {
            _onFailed = onFailed;

            return this;
        }

        public IEditor<TObject> OnModelInvalid(Action<ICollection<ValidationResult>> onModelInvalid)
        {
            _onModelInvalid = onModelInvalid;

            return this;
        }

        public IEditor<TObject> OnSuccess(Action<TObject> onSuccess)
        {
            _onSuccess = onSuccess;

            return this;
        }

        public DialogResult Open()
        {
            try
            {
                EditorMapper.MapToEditor(Editor, EditableObject);

                if(Editor.ShowDialog() == DialogResult.OK)
                {
                    var validationResult = new List<ValidationResult>();

                    EditorMapper.MapFromEditor(Editor, EditableObject);

                    if (_onModelInvalid != default)
                    {
                        if(!Validator.TryValidateObject(EditableObject, new ValidationContext(EditableObject), validationResult))
                        {
                            _onModelInvalid.Invoke(validationResult);

                            return DialogResult.Abort;
                        }
                    }

                    _onSuccess?.Invoke((TObject)EditableObject);

                    return DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                if (_onFailed != default) _onFailed.Invoke(ex);
                else throw;
            }

            return DialogResult.Abort;
        }
    }
}
