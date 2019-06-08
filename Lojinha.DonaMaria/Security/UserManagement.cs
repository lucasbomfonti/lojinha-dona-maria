using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Exception;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lojinha.DonaMaria.Security
{
    public static class UserManagement
    {
        private static IList<UserInfo> _users;

        public static UserInfo GetUser(Guid token)
        {
            _users = _users ?? new List<UserInfo>();

            var user = _users.FirstOrDefault(f => f.Token.Equals(token));
            if (user == null || user.LastConnection < DateTime.Now.AddMinutes(10))
                throw new TokenException("Sua sessão foi encerrada");

            user.LastConnection = DateTime.Now;
            return user;
        }

        public static Guid RegisterUser(User profile)
        {
            _users = _users ?? new List<UserInfo>();

            if (!_users.Any(a => a.Id.Equals(profile.Id)))
                _users.Add(new UserInfo(profile.Id, Guid.NewGuid(), null));

            return _users.FirstOrDefault(f => f.Id.Equals(profile.Id)).Token;
        }

        public static void Validate(HttpRequest request)
        {
            var header = request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("authorization"));

            if (!header.Value.ToList().Any())
                throw new TokenException("O token de autorização está ausente");

            var tokenRequest = header.Value.ToArray()[0];
            var token = Guid.Empty;
            if (string.IsNullOrEmpty(tokenRequest) || !Guid.TryParse(tokenRequest, out token) || token == Guid.Empty)
                throw new TokenException("Token de autorização inválido");
        }
    }

    public class UserInfo
    {
        public UserInfo(Guid id, Guid newGuid, Guid? token)
        {
            Id = id;
            if (token == null) Token = newGuid;
            LastConnection = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid Token { get; set; }
        public DateTime LastConnection { get; set; }
    }
}
