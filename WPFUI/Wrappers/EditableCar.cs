using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kups.CarBrowser.BO;
using WPFUI.Models;

namespace WPFUI.Wrappers
{
    public class EditableCar : ViewModelBase<Car>
    {
        private long _id;
        private CarType _carType;
        private string _model;
        private string _manufacturer;
        private int _productionYear;
        private GearBox _gearBox;
        private Color _color;
        private long _engineId;
        private string _engineName;
        private EngineType _engineType;
        private int _horsePower;

        public List<CarType> CarTypes => GetListOfType<CarType>();
        public List<EngineType> EngineTypes => GetListOfType<EngineType>();
        public List<GearBox> GearBoxes => GetListOfType<GearBox>();

        public static List<T> GetListOfType<T>() => Enum.GetValues(typeof(T)).Cast<T>().ToList();


        public EditableCar(Car car, RelayCommand commitCmd) : base(car != null, commitCmd)
        {
            if (car == null) return;
            _carType = car.CarType;
            _model = car.Model;
            _id = car.Id;
            _manufacturer = car.Manufacturer;
            _productionYear = car.ProductionYear;
            _gearBox = car.GearBox;
            _color = car.Color;
            _engineId = car.Engine.Id;
            _engineName = car.Engine.Name;
            _engineType = car.Engine.Type;
            _horsePower = car.Engine.HorsePower;
        }

        [Range(1, int.MaxValue, ErrorMessage = "Id must be positive")]
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

        public CarType CarType
        {
            get => _carType;
            set
            {
                _carType = value;
                OnPropertyChanged(nameof(CarType));
                Validate();
            }
        }

        [Required(ErrorMessage = "Model name is required")]
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
                Validate();
            }
        }

        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(Manufacturer));
                Validate();
            }
        }

        [Range(1900, int.MaxValue, ErrorMessage = "Production year must be after 1900")]
        public int ProductionYear
        {
            get => _productionYear;
            set
            {
                _productionYear = value;
                OnPropertyChanged(nameof(ProductionYear));
                Validate();
            }
        }

        [Required(ErrorMessage = "Gear box type is required")]
        public GearBox GearBox
        {
            get => _gearBox;
            set
            {
                _gearBox = value;
                OnPropertyChanged(nameof(GearBox));
                Validate();
            }
        }

        [Required(ErrorMessage = "Color is required")]
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
                Validate();
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Engine Id must be positive")]
        public long EngineId
        {
            get => _engineId;
            set
            {
                _engineId = value;
                OnPropertyChanged(nameof(EngineId));
                Validate();
            }
        }

        [Required(ErrorMessage = "Engine name is required")]
        public string EngineName
        {
            get => _engineName;
            set
            {
                _engineName = value;
                OnPropertyChanged(nameof(EngineName));
                Validate();
            }
        }

        public EngineType EngineType
        {
            get => _engineType;
            set
            {
                _engineType = value;
                OnPropertyChanged(nameof(EngineType));
                Validate();
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Horse power must be positive")]
        public int HorsePower
        {
            get => _horsePower;
            set
            {
                _horsePower = value;
                OnPropertyChanged(nameof(HorsePower));
                Validate();
            }
        }

        public override Car CommitChanges() =>
            new Car(Id, CarType, Model, Manufacturer, ProductionYear, GearBox, Color,
                new Engine(EngineId, EngineName, EngineType, HorsePower));
    }
}