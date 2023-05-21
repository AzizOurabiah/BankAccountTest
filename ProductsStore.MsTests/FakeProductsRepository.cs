
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
    class FakeProductsRepository : IProductsRepository
    {
        private List<Product> _products;

        public FakeProductsRepository(List<Product> products)
        {
            _products = products;
        }

        public async Task<Product> Add(Product product)
        {
            _products.Add(product);
            return product;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return _products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = _products.Find(x => x.Id == id);
            return product;
        }

        public async Task<Product> Remove(int id)
        {
            var product = _products.Find(x => x.Id == id);
            _products.Remove(product);

            return product;
        }

        public async Task<Product> Update(int id, Product product)
        {
            var item = _products.Find(x => x.Id == id);

            _products[id].Name = product.Name;
            return item;

        }
    }
}