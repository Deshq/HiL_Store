using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Services.CreationService
{
    public class ProductCreationService : IProductCreationService
    {
        private readonly IProductService _productService;

        private readonly ICategoryProductService _categoryProductService;

        public ProductCreationService(IProductService productService, ICategoryProductService categoryProductService)
        {
            this._productService = productService;
            this._categoryProductService = categoryProductService;
        }

        public async Task<CreationProductResult> Creation(string name, int price, Category category)
        {
            CreationProductResult result = CreationProductResult.SuccessCreation;

            if (name == null || price == 0 || category == null)
            {
                result = CreationProductResult.EmptyData;
            }


            Product nameProduct = await _productService.GetByProduct(name);
            if (nameProduct != null)
            {
                result = CreationProductResult.ProductAlreadyExists;
            }

            if (result == CreationProductResult.SuccessCreation)
            {
                Product product = new Product()
                {
                    Name = name,
                    Price = price
                };

                await _productService.Create(product);

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryID = category.Id,
                    ProductID = product.Id
                };

                await _categoryProductService.Create(categoryProduct);
            }

            return result;
        }
    }
}
