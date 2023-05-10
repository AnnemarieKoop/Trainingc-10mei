using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10mei
{
    public class InMemoryProductRepository : ProductRepository
    {
        public static Dictionary<int, Product> products = new Dictionary<int, Product>() 
        {
            { 123, new Product(123,"toetsenbord","om mee te typen",13.95,11 ) },
            { 124, new DigitalProduct("newlicense123456789",124, "MS Powerpoint", "om mooie slides te maken", 55.99, 100) },
            { 78, new Product(78, "muis", "om mee te klikken", 8.95, 20) },
            { 903, new DigitalProduct("welcome987654321", 903, "VisualStudio", "om mooie code te maken", 110.95, 83) }
        };


        public InMemoryProductRepository() 
        { 
        }

        public override List<Product> GetProducts()
        {
            return products.Values.ToList();
        }

        public override Product GetProductById(int id)
        {
            
            try
            {
                return products[id];
            }
            catch
            {
                throw new ProductNotFoundException("Niet-bestaand id ingevuld.");
            }
        } 
            

        public override List<Product> FilterProducts(Func<Product, bool> predicate)
        {
           return GetProducts().Where(predicate).Select(n => n).ToList();
        }

    }


}
