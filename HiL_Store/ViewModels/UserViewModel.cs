using HiL_Store.Commands;
using HiL_Store.Commands.CreationCommands;
using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HiL_Store.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
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

		private CategoryProduct _product;
		public CategoryProduct Product
		{
			get => _product;
			set
			{
				_product = value;
				OnPropertyChanged(nameof(Product));
			}
		}

		IEnumerable<CategoryProduct> _GetCollection2;
		public IEnumerable<CategoryProduct> GetCollection2
		{
			get => _GetCollection2;
			set
			{
				_GetCollection2 = value;
				OnPropertyChanged("GetCollection2");
			}
		}

		private string _result;
		public string Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		private int _count;
		public int Count
		{
			get => _count;
			set
			{
				_count = value;
				OnPropertyChanged(nameof(Count));
			}
		}

	
		private int _price;
		public int Price
		{
			get => _price;
			set
			{
				_price = _product.Product.Price;
				OnPropertyChanged(nameof(Price));
			}
		}

		public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

		public ICommand CategoryGetCommand { get; }

		public ICommand ChooseCategoryCommand { get; }

		public ICommand DisplayResultCommand { get; }

		public UserViewModel(ICategoryService categoryService, ICategoryProductService categoryProductService)
        {
            ErrorMessageViewModel = new MessageViewModel();

			ChooseCategoryCommand = new DisplayProductsCommand(this, categoryProductService);

			CategoryGetCommand = new GetCategoryCommand(this, categoryService);

			DisplayResultCommand = new DisplayResultCommand(this);

			CategoryGetCommand.Execute(categoryService);
		}
    }
}
