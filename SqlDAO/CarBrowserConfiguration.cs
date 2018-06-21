using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Kups.CarBrowser.SqlDAO
{
    public class CarBrowserConfiguration : DbConfiguration
    {
        public CarBrowserConfiguration()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}