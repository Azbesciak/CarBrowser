using System.IO;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;
using Kups.CarBrowser.JsonDAO.Properties;

namespace Kups.CarBrowser.JsonDAO
{
    public class JsonDao : IDao
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IDealersRepository _dealersRepository;

        public JsonDao()
        {
            var repoPath = Settings.Default.RepositoryPath;
            var carsFile = Settings.Default.CarsRepoFile;
            var dealersFile = Settings.Default.DealersRepoFile;

            _carsRepository = new JsonCarsRepository(Reader<Car>(repoPath, carsFile));
            _dealersRepository = new JsonDealersRepository(Reader<Dealer>(repoPath, dealersFile));
        }

        public ICarsRepository GetCarsRepository() => _carsRepository;

        public IDealersRepository GetDealersRepository() => _dealersRepository;

        private static JsonReader<T> Reader<T>(string root, string repoFile)
        {
            var fullPath = Path.Combine(root, repoFile);
            return new JsonReader<T>(fullPath);
        }
    }
}