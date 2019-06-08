using Microsoft.Extensions.DependencyInjection;

namespace Lojinha.DonaMaria
{
    public class ServiceFactory
    {
        private static ServiceProvider _servicesProvider;

        public static void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _servicesProvider = serviceProvider;
        }

        public static TS GetInstance<T, TS>()
        {
            return (TS)_servicesProvider.GetService(typeof(T));
        }
    }
}
