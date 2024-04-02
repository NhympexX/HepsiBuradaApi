using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Application.UnitOfWorks;
using HepsiBuradaApi.Persistance.Context;
using HepsiBuradaApi.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AppDbContext appDbContext;
        public UnitOfWork(AppDbContext context)
        {
            appDbContext = context;
        }
        public async ValueTask DisposeAsync() =>await appDbContext.DisposeAsync();
        public int Save() => appDbContext.SaveChanges();

        public async Task<int> SaveAsync()=> await appDbContext.SaveChangesAsync();

        IReadRepository<T> IUnitofWork.GetReadRepository<T>()=> new ReadRepository<T>(appDbContext);

        IWriteRepository<T> IUnitofWork.GetWriteRepository<T>()=> new WriteRepository<T>(appDbContext);
    }
}
