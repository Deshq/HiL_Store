using HiL_Store.Commands;
using HiL_Store.Commands.CreationCommands;
using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.State.Accounts;
using HiL_Store.State.Authenticators;
using HiL_Store.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HiL_Store.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {

		private string _categoryName;
		public string CategoryName
		{
			get => _categoryName;
			set
			{
				_categoryName = value;
				OnPropertyChanged(nameof(CategoryName));
			}
		}

		private Category _category;
		public Category Category
		{
			get => _category;
			set
			{
				_category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		IEnumerable<Category> _GetCollection;
		public IEnumerable<Category> GetCollection
		{
			get => _GetCollection;
			set
			{
				_GetCollection = value;
				OnPropertyChanged("GetCollection");
			}
		}

		private string _productName;
		public string ProductName
		{
			get => _productName;
			set
			{
				_productName = value;
				OnPropertyChanged(nameof(ProductName));
			}
		}

		private string _productPrice;
		public string ProductPrice
		{
			get => _productPrice;
			set
			{
				_productPrice = value;
				OnPropertyChanged(nameof(ProductPrice));
			}
		}


		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public MessageViewModel ErrorMessageViewModel2 { get; }

		public string ErrorMessage2
		{
			set => ErrorMessageViewModel2.Message = value;
		}

	

		public ICommand ViewLoginCommand { get; }
		public ICommand CategoryCreationCommand { get; }
		public ICommand ProductCreationCommand { get; }	
		public ICommand CategoryGetCommand { get; }

		public AdminViewModel(IRenavigator loginRenavigator, ICategoryCreationService categoryCreationService, IProductCreationService productCreationService, ICategoryService categoryService)
		{
			ErrorMessageViewModel = new MessageViewModel();
			ErrorMessageViewModel2 = new MessageViewModel();
;
			ViewLoginCommand = new RenavigateCommand(loginRenavigator);
			CategoryCreationCommand = new CategoryCreationCommand(this, categoryCreationService);		
			ProductCreationCommand = new ProductCreationCommand(this, productCreationService);		
			CategoryGetCommand = new CategoryGetCommand(this, categoryService);

			CategoryGetCommand.Execute(categoryService);

		}

	}
}
