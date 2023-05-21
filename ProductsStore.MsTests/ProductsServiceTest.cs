
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsStore.Models;
using ProductsStore.Services;
using System.Collections.Generic;

namespace ProductsStore.MsTests
{
    [TestClass]
    public class ProductsServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange

            var contextList = new List<Product>()
            {
                new Product{Id =1, Name = "Aziz-1"},
                new Product{Id =2, Name = "Aziz-2"},
                new Product{Id =3, Name = "Aziz-3"},
            };
            var repositorie = new FakeProductsRepository(contextList);

            ProductsService productsService_WithList = new ProductsService(repositorie);

            //Act
            var expected = productsService_WithList.Add(new Product { Id = 4, Name = "Aziz-4" }).Result.ToString();
            //var expected = productsService_WithList.Add(new Product { Id = 4, Name = "Aziz-4" }).Result;

            //var expected = new Product { Id = 4, Name = "Aziz-4" };


            var actual = new Product { Id = 4, Name = "Aziz-4" }.ToString();
            //var actual = new Product { Id = 4, Name = "Aziz-4" };

            //Assert
            Assert.AreEqual(expected, actual);


        }
    }
}
