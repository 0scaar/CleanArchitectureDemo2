using NorthWind.Entities.Interfaces;
using NorthWind.Repositories.EFCore.DataContext;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly NorthWindContext context;

        public UnitOfWork(NorthWindContext context)
        {
            this.context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
