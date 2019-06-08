using Lojinha.DonaMaria.Data.Service;
using Lojinha.DonaMaria.Data.Service.Interface;

namespace Lojinha.DonaMaria
{
    public class Agent
    {
        public void CreateDatabase()
        {
            try
            {
                ServiceFactory.GetInstance<IOrderService, OrderService>().CreateDatabase();
            }
            catch (System.Exception)
            {
            }
        }
    }
}
