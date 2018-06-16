using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.WPFUI.Wrappers;
using WPFUI.Annotations;

namespace Kups.CarBrowser.WPFUI.Models
{
    public abstract class ViewBase<T>: INotifyPropertyChanged
    {
        protected readonly IService<T> Service;
        private ViewModelBase<T> _editable;
        private T _current;

        public ObservableCollection<T> All { get; }

        public T Current
        {
            get => _current;
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));
                RaiseCanExecuteChanged();
            }
        }

        public ViewModelBase<T> Editable
        {
            get => _editable;
            set
            {
                _editable = value;
                OnPropertyChanged(nameof(Editable));
                RaiseCanExecuteChanged();
            }
        }

        public RelayCommand CreateCmd { get; }
        public RelayCommand CommitCmd { get; }
        public RelayCommand EditCmd { get; }
        public RelayCommand CancelCmd { get; }
        public RelayCommand RemoveCmd { get; }

        protected ViewBase(IService<T> service)
        {
            Service = service;
            All = new ObservableCollection<T>(service.GetAll());
            CreateCmd = new RelayCommand(o => CreateModel(), o => Editable == null);
            CommitCmd = new RelayCommand(o => CommitModel(), o => Editable != null && Editable.IsDirty && !Editable.HasErrors);
            EditCmd = new RelayCommand(o => CreateModel(Current), o => Current != null && Editable == null);
            CancelCmd = new RelayCommand(o => Cancel(), o => Editable != null);
            RemoveCmd = new RelayCommand(o => Remove(), o => Current != null && Editable == null);
        }

        protected void UpdateList()
        {
            All.Clear();
            Service.GetAll().ForEach(t => All.Add(t));
            OnPropertyChanged(nameof(All));
        }

        protected void CommitModel()
        {
            if (Editable == null || Editable.HasErrors) return;
            var obj = Editable.CommitChanges();
            if (Editable.IsEditMode)
                Service.Update(obj);
            else
                Service.Add(obj);
            Editable = null;
            UpdateList();
        }

        

        private void CreateModel(T existing = default(T))
        {
            Editable = CreateEditableModel(existing, CommitCmd);
        }

        protected abstract ViewModelBase<T> CreateEditableModel(T existing, RelayCommand commitCmd);

        private void Cancel()
        {
            Editable = null;
        }

        protected abstract long GetEntityId(T entity);

        private void Remove()
        {
            var wasRemoved = Service.Remove(GetEntityId(Current));
            if (!wasRemoved) return;
            Current = default(T);
            UpdateList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}