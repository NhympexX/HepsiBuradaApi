using HepsiBuradaApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class,IEntityBase, new()
    {
        Task addAsync(T entity);
        Task addRangeAsync(IList<T> entities);
        Task<T> updateAsync(T entity);
        Task hardDeleteAsync(T entity);

    }
}
