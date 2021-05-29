using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class DisplayProductsCommand : AsyncCommandBase
    {

        private readonly UserViewModel _userViewModel;
        private readonly ICategoryProductService _categoryProductService;

        public DisplayProductsCommand(UserViewModel userViewModel, ICategoryProductService categoryProductService)
        {
            this._userViewModel = userViewModel;
            this._categoryProductService = categoryProductService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _userViewModel.ErrorMessage = string.Empty;
         
            try
            {
                _userViewModel.GetCollection2 =  _categoryProductService.GetProductByCategory2(_userViewModel.Category);

                _userViewModel.GetCollection2.ToString();

            }
            catch (Exception)
            {
                _userViewModel.ErrorMessage = "Fail";
            }
        }

    }
}
