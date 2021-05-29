using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.EF.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.EF.Services
{
    public class CategoryProductDataService : ICategoryProductService
    {
        private readonly HiLDbContextCreate _contextFactory;
        private readonly NonQueryDataService<CategoryProduct> _nonQueryDataService;

        public CategoryProductDataService(HiLDbContextCreate contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<CategoryProduct>(contextFactory);
        }

        public async Task<CategoryProduct> Create(CategoryProduct entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<CategoryProduct> Get(int id)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                CategoryProduct entity = await context.CategoryProducts
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<CategoryProduct>> GetAll()
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<CategoryProduct> entities = await context.CategoryProducts
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<CategoryProduct> GetProductByCategory(Category entity)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.CategoryProducts
                    .Include(a => a.Product)
                    .FirstOrDefaultAsync(a => a.Category == entity);
            }
        }

        public List<CategoryProduct> GetProductByCategory2(Category entity)
        {
            using (HiLDbContext context = _contextFactory.CreateDbContext())
            {
                IQueryable<CategoryProduct> data = (from bm in context.CategoryProducts
                                                 join
                                                 b in context.Categories on bm.CategoryID equals b.Id
                                                 join m in context.Products on bm.ProductID equals m.Id
                                                 where bm.CategoryID == entity.Id
                                                 select bm)
                                            .Include(p => p.Product);

                return data.ToList();
            }
        }

        public async Task<CategoryProduct> Update(int id, CategoryProduct entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
