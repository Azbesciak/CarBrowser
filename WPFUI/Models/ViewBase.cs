using System.Collections.Generic;
using Kups.CarBrowser.Core;
using WPFUI.Wrappers;

namespace WPFUI.Models
{
    public abstract class ViewBase<T>
    {
        private readonly IService<T> _service;
        public List<T> All => _service.GetAll();
        public T Current { get; set; }
        public ViewModelBase<T> Editable { get; set; }
        public ViewBase(IService<T> service)
        {
            _service = service;
        }
    }
}