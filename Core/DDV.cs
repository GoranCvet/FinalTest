using System.Collections.Generic;
using System.Security.Cryptography;

namespace Core
{
    public class DDV
    {
        public DDV()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public double Tax { get; set; }
        public List<Product> Products { get; set; }
    }
}
