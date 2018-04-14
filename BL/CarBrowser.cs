using System;
using System.IO;
using System.Reflection;
using Kups.CarBrowser.BL.Properties;
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
            GetRequiredDependencies();
            var daoType = Settings.Default.DaoClassName;
            var daoDll = Settings.Default.DaoDllLocation;
            var package = GetPackage(daoDll);
            var type = package.GetType(daoType);

            return (IDao) Activator.CreateInstance(type, new object[] { });
        }

        private static void GetRequiredDependencies()
        {
            var requiredDlls = Settings.Default.RequiredDlls.Split(',');
            foreach (var dll in requiredDlls)
            {
                GetPackage(dll);
            }
        }

        private static Assembly GetPackage(string daoDll)
        {
            if (!daoDll.Contains(":"))
            {
                var root = Directory.GetParent(@"../../../").FullName;
                daoDll = Path.Combine(root, daoDll);
            }

            try
            {
                var package = Assembly.LoadFile(daoDll);
                AppDomain.CurrentDomain.Load(package.GetName());
                return package;
            }
            catch (Exception e)
            {
                Console.WriteLine("Some dependency is not correct; check in settings: {0}", e.Message);
                throw;
            }
        }
    }
}