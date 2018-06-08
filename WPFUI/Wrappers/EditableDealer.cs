using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kups.CarBrowser.BO;
using WPFUI.Models;

namespace WPFUI.Wrappers
{
    public class EditableDealer : ViewModelBase<Dealer>
    {
        private long _id;
        private string _name;
        private string _brands;

        public EditableDealer(Dealer dealer, RelayCommand commitCmd) : base(dealer != null, commitCmd)
        {
            if (dealer == null) return;
            Id = dealer.Id;
            Brands = string.Join(", ", dealer.Brands);
            Name = dealer.Name;
        }

        [Required(ErrorMessage = "Dealer's id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Dealer's id must be positive")]
        public long Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
                Validate();
            }
        }

        [Required(ErrorMessage = "Dealer's name is required")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Id));
                Validate();
            }
        }

        public string Brands
        {
            get => _brands;
            set
            {
                _brands = value;
                OnPropertyChanged();
                Validate();
            }
        }

        public override Dealer CommitChanges() => new Dealer(Id, Name,
            Brands.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToArray()
        );
    }
}