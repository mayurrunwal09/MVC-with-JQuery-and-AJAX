using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DBCONTEXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MainDBContext _context;
        private readonly DbSet<T> entites;
        public Repository(MainDBContext context)
        {
            _context = context;
            entites = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entites.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(int Id)
        {
            return entites.SingleOrDefault(e => e.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entites.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entites.Remove(entity);

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entites.Update(entity);
            _context.SaveChanges();
        }
    }
}