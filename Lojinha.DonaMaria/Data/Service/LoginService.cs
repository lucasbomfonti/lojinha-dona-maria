using Lojinha.DonaMaria.Data.Repository;
using Lojinha.DonaMaria.Domain;

namespace Lojinha.DonaMaria.Data.Service
{
    public class LoginService
    {
        private readonly LoginRepository _adminProfileRepository;

        public LoginService(LoginRepository adminProfileRepository)
        {
            _adminProfileRepository = adminProfileRepository;
        }

        public User login(string name, string password)
        {
            var temp = _adminProfileRepository.login(name, password);
            return temp;
        }
    }
}
