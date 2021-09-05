using System;
using Microsoft.EntityFrameworkCore;
using Sample.Repository.Interfaces;

namespace Sample.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private bool disposed;

        public UnitOfWork(DbContext context) => this.context =
            context ?? throw new ArgumentNullException(nameof(context), "Context can't be null");

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                this.context.Dispose();
            }

            this.disposed = true;
        }

        public int Commit() => this.context.SaveChanges();
    }
}
