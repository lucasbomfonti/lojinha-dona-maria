using System;

namespace Lojinha.DonaMaria.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created_at { get; set; }
    }
}
