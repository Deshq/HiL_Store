using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.EF.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.EF.Services
{
    public class ProductDataService : IProductService
    {
        private readonly HiLDbContextCreate _contextFactory;
        private readonly NonQueryDataService<Product> _nonQueryDataService;

        public ProductDataService(HiLDbContextCreate contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Product>(contextFactory);
        }

        public async Task<Product> Create(Product entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Product> Get(int id)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                Product entity = await context.Products
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Product> entities = await context.Products
                    .ToListAsync();
                return entities;
            }
        }


        public async Task<Product> GetByProduct(string name)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Products
                    .FirstOrDefaultAsync(a => a.Name == name);
            }
        }

        public async Task<Product> Update(int id, Product entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
