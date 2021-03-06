using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands.CreationCommands
{
    public class CategoryGetCommand : AsyncCommandBase
    {
        private readonly AdminViewModel _adminViewModel;
        private readonly ICategoryService _categoryService;

        public CategoryGetCommand(AdminViewModel adminViewModel, ICategoryService categoryService)
        {
            this._adminViewModel = adminViewModel;
            this._categoryService = categoryService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _adminViewModel.ErrorMessage = string.Empty;

            try
            {
                _adminViewModel.GetCollection = await _categoryService.GetAll();

                _adminViewModel.GetCollection.ToString();

            }
            catch (Exception)
            {
                _adminViewModel.ErrorMessage = "Get command fail";
            }

        }
    }
}
