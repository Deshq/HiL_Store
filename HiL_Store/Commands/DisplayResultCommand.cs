using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class DisplayResultCommand : AsyncCommandBase
    {
        private readonly UserViewModel _userViewModel;

        public DisplayResultCommand(UserViewModel userViewModel)
        {
            this._userViewModel = userViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _userViewModel.ErrorMessage = string.Empty;

            try
            {

                if (_userViewModel.Count < 0)
                {
                    _userViewModel.ErrorMessage = "Quantity cannot be negative";
                
                }
                if (_userViewModel.Count == 0)
                {
                    _userViewModel.ErrorMessage = "Empty Data. Choose quantity";
                }
                else
                {
                    _userViewModel.Result = "Your grocery bill: " + (_userViewModel.Product.Product.Price * _userViewModel.Count).ToString() + " $";
                }
               
            }
            catch (Exception)
            {
                 _userViewModel.ErrorMessage = "Fail";
            }
        }
    }
}
