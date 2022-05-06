using PasteBook.WebApi.Repositories;
using System;
using System.Threading.Tasks;

namespace PasteBook.WebApi.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        public IUserRepository UserRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private PasteBookDb context;

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(PasteBookDb context)
        {
            this.context = context;
            this.UserRepository = new UserRepository(context);
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
