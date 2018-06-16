using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Kups.CarBrowser.WPFUI.Wrappers
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public bool IsEditMode { get; }
        public bool IsDirty { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            IsDirty = true;
        }

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        protected ViewModelBase(bool isEditMode)
        {
            IsEditMode = isEditMode;
        }

        public IEnumerable GetErrors(string propertyName) =>
            _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;

        public bool HasErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void Validate()
        {
            var validatonContext = new ValidationContext(this, null, null);
            var validationResult = new List<ValidationResult>();
            Validator.TryValidateObject(this, validatonContext, validationResult, true);
            foreach (var kv in _errors.ToList())
            {
                if (!validationResult.All(r => r.MemberNames.All(m => m != kv.Key))) continue;
                _errors.Remove(kv.Key);
                OnErrorChanged(kv.Key);
            }

            var q = from e in validationResult
                from m in e.MemberNames
                group e by m
                into g
                select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();
                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                OnErrorChanged(prop.Key);
            }
        }

        public abstract T CommitChanges();
    }
}
