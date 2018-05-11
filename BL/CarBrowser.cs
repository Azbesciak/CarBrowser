using System;
using System.IO;
using System.Linq;
using System.Reflection;
using ConfigUtils;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
{
    public class CarBrowser
    {
        public ICarsService CarsService { get; }
        public IDealersService DealersService { get; }

        public CarBrowser()
        {
            var dao = CreateDao();
            CarsService = new CarsService(dao.GetCarsRepository());
            DealersService = new DealersService(dao.GetDealersRepository());
        }

        private static IDao CreateDao()
        {
            var daoDll = Config.ReadSetting("DaoDllLocation");
            var package = Config.GetPackage(daoDll);
            var allImplementations = package.DefinedTypes
                .Where(t => t.GetInterfaces().Contains(typeof(IDao)))
                .ToArray();
            switch (allImplementations.Length)
            {
                case 1: return (IDao)Activator.CreateInstance(allImplementations[0], new object[] { });
                case 0: throw new NullReferenceException($"Implementation of IDao was not found in {daoDll}");

                default:
                    throw new ArgumentException($"found {allImplementations.Length} implementations of IDao");
            }
        }
    }
}