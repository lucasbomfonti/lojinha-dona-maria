using Lojinha.DonaMaria;
using Lojinha.DonaMaria.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Tmss_Back_end.Data.Repository.Context;
using Tmss_Back_end.Data.Repository.Interface.Base;

namespace Tmss_Back_end.Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public virtual Guid Add(T entity)
        {
            entity.Id = new Guid();
            entity.Created_at = DateTime.Now;
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public virtual T Update(T entity)
        {
            var user = Get(entity.Id);
            SetValue(user, entity);
            _context.SaveChanges();
            return user;
        }

        public virtual void Remove(Guid id)
        {
            if (Get(id) == null)
                throw new Exception("Id not Found");
            _context.Remove(Get(id));
            _context.SaveChanges();
        }

        public virtual T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual List<T> All()
        {
            return _context.Set<T>().ToList();
        }

        protected virtual void SetValue(T ent, T newValue)
        {
            _context.Entry(ent).CurrentValues.SetValues(newValue);
            InternalSetValue(ent, newValue);
        }

        protected virtual void InternalSetValue(object ent, object newValue)
        {
        }

        protected virtual TTi ExtractItemFromContext<TTi>(TTi query)
        {
            var temp = JsonConvert.SerializeObject(query, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return JsonConvert.DeserializeObject<TTi>(temp);
        }

        public void CreateDatabase()
        {
            _context.Database.Migrate();
            Seed();
        }
        protected virtual void Seed()
        {
            using (_context)
            {
                UserSeed.Run(_context);
                OrderSeed.Run(_context);
            }
        }
    }
}