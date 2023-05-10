namespace _10mei
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome customer! Below is a menu. Type the number of the thing you want to do." +
                "\n1. View all products" +
                "\n2. View product details by id" +
                "\n3. Add a product tot the cart by id" +
                "\n4. Remove a product from the cart by id" +
                "\n5. View cart items and total" +
                "\n6. Clear the cart" +
                "\n7. Filter products by a certain property" +
                "\nx. Exit this store");
            string choice = "";
            List<Product> prods = new InMemoryProductRepository().GetProducts();
            while (choice != "x")
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Id\t|\tProductname");
                        foreach (Product p in prods)
                        {
                            Console.WriteLine(+p.Id + "\t|\t" + p.Name);
                        }
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                    case "2":
                        Console.WriteLine("Please enter the id of the product you want details about:");
                        int id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Id\t|\tProductname\t|\tDescription\t|\tPrice\t|\tQuantity in stock");
                        Product product = new InMemoryProductRepository().GetProductById(id);
                        Console.WriteLine($"{product.Id,-10}| {product.Name,-10}| {product.Description,-20}| {product.Price,-10}| {product.Quantity}");
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                    case "3":
                        Console.WriteLine("Enter the id of the product you want:");
                        int id2 = Int32.Parse(Console.ReadLine());
                        Product product2 = new InMemoryProductRepository().GetProductById(id2);
                        Console.WriteLine($"Ok. How many of {product2.Name} do you want?");
                        int q = Int32.Parse(Console.ReadLine());
                        Cart.AddItem(id2, q);
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                    case "4":
                        Console.WriteLine("Enter the id of the product you want to remove:");
                        int id3 = Int32.Parse(Console.ReadLine());
                        Product product3 = new InMemoryProductRepository().GetProductById(id3);
                        Cart.RemoveItem(id3);
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                    case "5":
                        Console.WriteLine($"Your cart contains {Cart.GetItemCount()} items, with a total amount of {Cart.GetTotal()} euro's:");
                        foreach (var item in Cart.items)
                        {
                            Product p = new InMemoryProductRepository().GetProductById(item.Key);
                            Console.WriteLine($"{item.Value} of {p.Name}, which costs {p.Price} apiece.");
                        }
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                    case "6":
                        Cart.Clear();
                        Console.WriteLine("Your cart is now cleared.");
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                    case "7":
                        Console.WriteLine("You can choose to filter by the following options:" +
                            "\nA. Name" +
                            "\nB. Description" +
                            "\nC. Max price" +
                            "\nD. Min quantity" +
                            "\nWhich do you choose?");
                        string fchoice = Console.ReadLine();
                        switch(fchoice)
                        {
                            case "A":
                                Console.WriteLine("Which product name do you want to filter by? Choose from muis/toetsenbord/Visual Studio/MS Powerpoint.");
                                string fprod = Console.ReadLine();
                                Func<Product, bool> predicate = x => x.Name == fprod;
                                List<Product> flist = new InMemoryProductRepository().FilterProducts(predicate);
                                Console.WriteLine("Your filtered products are:");
                                foreach (Product fp in flist)
                                {
                                    Console.WriteLine($"{fp.Name}, {fp.Id}, {fp.Description}, {fp.Price},{fp.Quantity} ");
                                }
                                break;
                            case "B":
                                Console.WriteLine("Which letter must the description contain?");
                                string fdescription = Console.ReadLine();
                                Func<Product, bool> predicate2 = x => x.Description.Contains(fdescription);
                                List<Product> flist2 = new InMemoryProductRepository().FilterProducts(predicate2);
                                Console.WriteLine("Your filtered products are:");
                                foreach (Product fp in flist2)
                                {
                                    Console.WriteLine($"{fp.Name}, {fp.Id}, {fp.Description}, {fp.Price},{fp.Quantity} ");
                                }
                                break;
                            case "C":
                                Console.WriteLine("What is the max price you want to pay? Enter a number.");
                                double fmaxprice = Double.Parse(Console.ReadLine());
                                Func<Product, bool> predicate3 = x => x.Price <= fmaxprice;
                                List<Product> flist3 = new InMemoryProductRepository().FilterProducts(predicate3);
                                Console.WriteLine("Your filtered products are:");
                                foreach (Product fp in flist3)
                                {
                                    Console.WriteLine($"{fp.Name}, {fp.Id}, {fp.Description}, {fp.Price},{fp.Quantity} ");
                                }
                                break;
                            case "D":
                                Console.WriteLine("What is the min quantity that must be available?");
                                int fminq = Int32.Parse(Console.ReadLine());
                                Func<Product, bool> predicate4 = x => x.Quantity >= fminq;
                                List<Product> flist4 = new InMemoryProductRepository().FilterProducts(predicate4);
                                Console.WriteLine("Your filtered products are:");
                                foreach (Product fp in flist4)
                                {
                                    Console.WriteLine($"{fp.Name}, {fp.Id}, {fp.Description}, {fp.Price},{fp.Quantity} ");
                                }
                                break;

                        }
                        Console.WriteLine("Perfect. What is the next thing you want to do from the menu?");
                        break;
                        
                    case "x":
                        Console.WriteLine("Bye!");
                        break;
                }
            }
        }
    }
}