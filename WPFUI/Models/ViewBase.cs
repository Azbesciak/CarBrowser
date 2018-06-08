using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using WPFUI.Annotations;
using WPFUI.Wrappers;
using static System.Windows.Input.CommandManager;

namespace WPFUI.Models
{
    public abstract class ViewBase<T>: INotifyPropertyChanged
    {
        protected readonly IService<T> Service;
        private ViewModelBase<T> _editable;
        private T _current;

        public ObservableCollection<T> All { get; set; }

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

        public ICommand CreateCmd { get; }
        public ICommand CommitCmd { get; }
        public ICommand EditCmd { get; }
        public ICommand CancelCmd { get; }
        public ICommand RemoveCmd { get; }

        protected ViewBase(IService<T> service)
        {
            Service = service;
            All = new ObservableCollection<T>(service.GetAll());
            CreateCmd = new RelayCommand(o => CreateModel(), o => true || Editable == null);
            CommitCmd = new RelayCommand(o => CommitModel(), o => true || Editable != null && !Editable.HasErrors);
            EditCmd = new RelayCommand(o => CreateModel(Current), o => true||Current != null && Editable == null);
            CancelCmd = new RelayCommand(o => Cancel(), o => true||Editable != null);
            RemoveCmd = new RelayCommand(o => Remove(), o => true||Current != null && Editable == null);
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

        public event EventHandler CanExecuteChanged
        {
            add => RequerySuggested += value;
            remove => RequerySuggested -= value;
        }

        private void CreateModel(T existing = default(T))
        {
            Editable = CreateEditableModel(existing);
        }

        protected abstract ViewModelBase<T> CreateEditableModel(T existing);

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
            InvalidateRequerySuggested();
        }
    }
}