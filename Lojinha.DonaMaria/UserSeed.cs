using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Helper;
using System;
using System.Linq;
using Tmss_Back_end.Data.Repository.Context;

namespace Lojinha.DonaMaria
{
    public static class UserSeed
    {
        public static void Run(DataContext context)
        {
            if (context.Set<User>().Any())
                return;
            context.Set<User>().Add(new User()
            {
                Id = Guid.NewGuid(), Created_at = DateTime.Now, Nome = "admin",
                Password = EncryptHelper.EncryptPassword("123456")
            });
            context.SaveChanges();
        }
    }
}
