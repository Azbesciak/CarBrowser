using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kups.CarBrowser.BL;
using WPFUI.Models;

namespace WPFUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly CarBrowser CarBrowser = new CarBrowser();
        private readonly List<Lazy<object>> _pages = new List<Lazy<object>>(new[]
        {
            new Lazy<object>(() => new CarsViewModel(CarBrowser.CarsService)),
            new Lazy<object>(() => new DealersViewModel(CarBrowser.DealersService))
        });

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _pages[0].Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button) e.Source).Uid);
            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);
            DataContext = _pages[index].Value;
        }
    }
}