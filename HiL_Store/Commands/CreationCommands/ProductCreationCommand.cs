using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands.CreationCommands
{
    public class ProductCreationCommand : AsyncCommandBase
    {

        private readonly AdminViewModel _adminViewModel;
        private readonly IProductCreationService _productCreationService;

        public ProductCreationCommand(AdminViewModel adminViewModel, IProductCreationService productCreationService)
        {
            this._adminViewModel = adminViewModel;
            this._productCreationService = productCreationService;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            _adminViewModel.ErrorMessage2 = string.Empty;

            try
            {
                CreationProductResult result = await _productCreationService.Creation(_adminViewModel.ProductName, 
                    Convert.ToInt32(_adminViewModel.ProductPrice), _adminViewModel.Category);
                switch (result)
                {
                    case CreationProductResult.SuccessCreation:
                        _adminViewModel.ErrorMessage2 = "Success creation quiz.";
                        break;
                    case CreationProductResult.EmptyData:
                        _adminViewModel.ErrorMessage2 = "Enter the data";
                        break;
                    case CreationProductResult.ProductAlreadyExists:
                        _adminViewModel.ErrorMessage2 = "Product already exist.";
                        break;         
                    default:
                        _adminViewModel.ErrorMessage2 = "Creation product failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _adminViewModel.ErrorMessage2 = "Failed";
            }
        }
    }
}
