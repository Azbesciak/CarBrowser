
namespace Kups.CarBrowser.DAO
{
    public interface IDao
    {
        ICarsRepository GetCarsRepository();
        IDealersRepository GetSellersRepository();
    }
}