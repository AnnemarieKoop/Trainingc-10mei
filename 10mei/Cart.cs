using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10mei
{
    public static class Cart
    {
        public static Dictionary<int, int> items = new Dictionary<int, int>(); 
        private static ProductRepository p = new InMemoryProductRepository();

        public static void AddItem(int productId, int quantity)
        {
            items.Add(productId, quantity);
        }

        public static void RemoveItem(int productId)
        {
            items.Remove(productId);
        }

        public static void Clear() 
        {
            items.Clear();
        }

        public static double GetTotal()
        {
            double total = 0;
            foreach (var item in items) 
            {
                Product prod = p.GetProductById(item.Key);
                double price = prod.Price;
                int quantity = item.Value;
                total += (price * quantity);
            }
            return total;  
        }

        public static int GetItemCount()
        {
            int count = 0;
            foreach (var item in items) 
            {
                count += item.Value;
            }
            return count;
        }
        
    }
}
