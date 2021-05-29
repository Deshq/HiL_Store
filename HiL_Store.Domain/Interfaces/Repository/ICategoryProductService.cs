using HiL_Store.Domain.Entities.StoreEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces.Repository
{
    public interface ICategoryProductService : IGenericDataService<CategoryProduct>
    {
        Task<CategoryProduct> GetProductByCategory(Category entity);

        List<CategoryProduct> GetProductByCategory2(Category entity);
    }
}
