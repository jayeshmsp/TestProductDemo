using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccessLayer.Utils
{
    public interface IBaseRepository<Key, T, Result>
    {
        Task<Key> Create(T entity);
        Task Update(T entity);
        Task Delete(Key id);
        Task<Result> Read(Key id);
    }
}
