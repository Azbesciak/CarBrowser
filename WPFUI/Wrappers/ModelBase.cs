using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Models
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName) =>
            _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;

        public bool HasErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void RemoveErrors(string propertyName) => _errors.Remove(propertyName);

        protected void AddError(string propertyName, string errorMsg)
        {
            var errors = _errors[propertyName] ?? (_errors[propertyName] = new List<string>());
            errors.Add(errorMsg);
        }

        public abstract T CommitChanges();
    }
}
