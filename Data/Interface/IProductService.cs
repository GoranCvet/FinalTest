using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product CreateProduct(Product product);
        int Commit();
    }
}
