using NUnit.Framework;
using HiL_Store.Domain.Services.CreationService;
using System;
using System.Collections.Generic;
using System.Text;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.Domain.Interfaces.CreationService;
using Moq;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Services.CreationService.Tests
{
    [TestFixture()]
    public class CategoryCreationServiceTests
    {
        private Mock<ICategoryService> _mockCategoryService;

        private CategoryCreationService _сategoryCreationService;

        [SetUp]
        public void SetUp()
        {
            _mockCategoryService = new Mock<ICategoryService>();
            _сategoryCreationService = new CategoryCreationService(_mockCategoryService.Object);
        }

        [Test]
        public async Task Creation_WithAlreadyExistingCategory_ReturnsCategoryAlreadyExists()
        {
            string category = "Fruits";

            _mockCategoryService.Setup(s => s.GetByCategory(category)).ReturnsAsync(new Entities.StoreEntities.Category());
            CreationCategoryResult expected = CreationCategoryResult.CategoryAlreadyExists;

            CreationCategoryResult actual = await _сategoryCreationService.Creation(category);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Creation_WithZeroCategory_ReturnsEmptyData()
        {
            CreationCategoryResult expected = CreationCategoryResult.EmptyData;

            CreationCategoryResult actual = await _сategoryCreationService.Creation(It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Creation_WithNonExistingCategory_ReturnsSuccess()
        {
            string category = "Fruits";

            CreationCategoryResult expected = CreationCategoryResult.SuccessCreation;

            CreationCategoryResult actual = await _сategoryCreationService.Creation(category);

            Assert.AreEqual(expected, actual);
        }



    }
}