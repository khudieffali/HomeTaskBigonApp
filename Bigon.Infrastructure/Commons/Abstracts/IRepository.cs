using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Commons.Abstracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);

        Task<T> GetById(Expression<Func<T, bool>> predicate = null);

        Task<T> Add(T color);

        T Edit(T color);

        void Remove(T color);


        Task<int> Save();

    }
}
