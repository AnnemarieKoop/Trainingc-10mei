using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10mei
{
    public abstract class ProductRepository
    {
        public abstract List<Product> GetProducts();
        public abstract Product GetProductById(int id);
        public abstract List<Product> FilterProducts(Func<Product, bool> predicate);
    }
}
