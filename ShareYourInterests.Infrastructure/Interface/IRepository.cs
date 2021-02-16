using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShareYourInterests.Infrastructure.Interface
{
    public interface IRepository<T,TDbContext> where T:class where TDbContext:DbContext
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T FirstOrDefault(Expression<Func<T, bool>> exp);
    }
}
