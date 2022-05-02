using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
