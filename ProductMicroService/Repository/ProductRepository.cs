using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProductMicroService.DBContexts;
using ProductMicroService.Models;

namespace ProductMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        public readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int ProductId)
        {
            var product = _dbContext.Products.Find(ProductId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                Save();
            }
        }

        public Product? GetProductByID(int ProductId)
        {
            return _dbContext.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Products.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {            
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
