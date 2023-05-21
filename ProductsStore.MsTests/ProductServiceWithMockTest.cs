
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductsStore.Models;
using ProductsStore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.MsTests
{
    [TestClass]
    class ProductServiceWithMockTest
    {
        //On un moq répository avec la framwork Moq

        //On a crée un objet Moq de type IProductsRepository
        private readonly Mock<IProductsRepository> _mockProductsRepository;

        private Product _product;

        private IEnumerable<Product> _products;

        public ProductServiceWithMockTest()
        {
            _product = new Product
            {
                Id = 1,
                Name = "Laptop"
            };
            _products = new List<Product> { _product };

            //Initialisation de notre objet Moq
            _mockProductsRepository = new Mock<IProductsRepository>();
        }
        [TestMethod]
        public async Task GetAllProducts_ReturnsAvailableProducts()
        {
            //Arrange
            _mockProductsRepository.Setup(x => x.GetAllProducts())
                .Returns(Task.FromResult(_products));

            var sut = new ProductsService(_mockProductsRepository.Object);

            //Act
            var actual = await sut.GetAllProducts();


            //Assert
            Assert.IsTrue(actual.ToList().Count > 0);
        }
        [TestMethod]
        public async Task GetProductById_ReturnsAvailaibleProduct()
        {
            //Arrange
            _mockProductsRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(_product));

            //On récupère l'objet de retour de Moq

            var sut = new ProductsService(_mockProductsRepository.Object);

            //Act 
            var actual = sut.GetById(1);
            var expected = new Product { Id = 1, Name = "Laptop" };

            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public async Task UpdateProduct_ReturnsProduct()
        {
            //On crée Moq Repository
            _mockProductsRepository.Setup(x => x.Update(1, _product))
                .Returns(Task.FromResult(_product));

            //Arrange
            var sut = new ProductsService(_mockProductsRepository.Object);

            //Act 
            var actual = sut.Update(1, _product);

            var expected = new Product { Id = 1, Name = "Laptop" };

            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}