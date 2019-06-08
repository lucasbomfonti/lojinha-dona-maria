using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Exception;
using Lojinha.DonaMaria.Helper;
using System.Linq;
using Tmss_Back_end.Data.Repository.Base;
using Tmss_Back_end.Data.Repository.Context;

namespace Lojinha.DonaMaria.Data.Repository
{
    public class LoginRepository : BaseRepository<User>
    {
        public LoginRepository(DataContext context) : base(context)
        {
            
        }

        public User login(string name, string password)
        {
            var encrypt = EncryptHelper.EncryptPassword(password);
            var temp = _context.Set<User>().FirstOrDefault(f => f.Nome.Equals(name) && f.Password.Equals(encrypt));
            if (temp == null)
                throw new TokenException("Usuario não cadastrado!!");
            return temp;
        }
    }
}
