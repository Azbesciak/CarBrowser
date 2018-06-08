using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace WPFUI.Wrappers
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public bool IsEditMode { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

        protected ViewModelBase(bool isEditMode)
        {
            IsEditMode = isEditMode;
        }

        public IEnumerable GetErrors(string propertyName) =>
            Errors.ContainsKey(propertyName) ? Errors[propertyName] : null;

        public bool HasErrors => Errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void RemoveErrors(string propertyName)
        {
            Errors.Remove(propertyName);
        }

        protected void AddError(string propertyName, string errorMsg)
        {
            var errors = Errors.ContainsKey(propertyName)
                ? Errors[propertyName]
                : (Errors[propertyName] = new List<string>());
            errors.Add(errorMsg);
        }

        protected void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void Validate()
        {
            var validatonContext = new ValidationContext(this, null, null);
            var validationResult = new List<ValidationResult>();
            Validator.TryValidateObject(this, validatonContext, validationResult, true);
            foreach (var kv in Errors.ToList())
            {
                if (!validationResult.All(r => r.MemberNames.All(m => m != kv.Key))) continue;
                Errors.Remove(kv.Key);
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
                if (Errors.ContainsKey(prop.Key))
                {
                    Errors.Remove(prop.Key);
                }
                Errors.Add(prop.Key, messages);
                OnErrorChanged(prop.Key);
            }
        }

        public abstract T CommitChanges();
    }
}
