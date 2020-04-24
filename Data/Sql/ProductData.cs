using Core;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Sql
{
    public class ProductData : IProductService
    {
        private readonly UjpDbContext dbContext;

        public ProductData(UjpDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Product CreateProduct(Product product)
        {
            var temp = dbContext.Products.Add(product);
            return temp.Entity;
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
