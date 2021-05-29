using HiL_Store.Domain.Entities.StoreEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces.CreationService
{
    public enum CreationProductResult
    {
        SuccessCreation,
        ProductAlreadyExists,
        EmptyData
    }

    public interface IProductCreationService
    {
        Task<CreationProductResult> Creation(string name, int price, Category category);
    }
}
