using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShareYourInterests.Infrastructure.Interface;

namespace ShareYourInterests.Infrastructure
{
    public class BaseRepository<T, TDbContext> : IRepository<T, TDbContext> where T : Entity.Entity where TDbContext : DbContext
    {
        private TDbContext _context;

        public BaseRepository(TDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
           return _context.Set<T>().FirstOrDefault(exp);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
