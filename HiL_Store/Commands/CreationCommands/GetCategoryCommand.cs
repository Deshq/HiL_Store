using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands.CreationCommands
{
    public class GetCategoryCommand : AsyncCommandBase
    {
        private readonly UserViewModel _userViewModel;
        private readonly ICategoryService _categoryService;

        public GetCategoryCommand(UserViewModel userViewModel, ICategoryService categoryService)
        {
            this._userViewModel = userViewModel;
            this._categoryService = categoryService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _userViewModel.ErrorMessage = string.Empty;

            try
            {
                _userViewModel.GetCollection = await _categoryService.GetAll();

            }
            catch (Exception)
            {
                _userViewModel.ErrorMessage = "Get command fail";
            }

        }
    }
}
