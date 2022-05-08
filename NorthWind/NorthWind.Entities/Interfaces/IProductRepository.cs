using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using System.Collections.Generic;

namespace NorthWind.Entities.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByEspecification(Specification<Product> specification);
    }
}
