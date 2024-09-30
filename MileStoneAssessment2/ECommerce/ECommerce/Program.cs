namespace ECommerce
{
        internal class Program
        {
            static void Main(string[] args)
            {
                // Create some products
                Product firstProduct = new Product("Laptop", 55000, "Electronics");
                Product secondProduct = new Product("Headphones", 4000, "Accessories");

                // Create a user
                User user = new User("mintra", "password123", "mintra@abc.com");

                // Create an order and add products to it
                Order order = new Order();
                order.AddProduct(firstProduct);
                order.AddProduct(secondProduct);

                // Display user info
                user.DisplayUser();

                // Display order details
                order.DisplayOrder();

                Customer customer = new Customer("Alice", "alice@example.com", "C123");
                Admin admin = new Admin("Bob", "bob@example.com", "A456");

                customer.DisplayPersonInfo();
                customer.PlaceOrder();

                admin.DisplayPersonInfo();
                admin.ManageSystem();

                Console.WriteLine(order.CalculateTotal());
                order.AddProduct("Keyboard", 2990, "Electronics");
                order.DisplayOrder();

                DiscountedOrder discountedOrder = new DiscountedOrder { Total = 200 };
                discountedOrder.Discount = 2;
                Console.WriteLine("Discounted total : " + discountedOrder.CalculateTotal());

                firstProduct.UpdatePrice(700);
                order.DisplayOrder();

                user.UpdateUser("abraham", "abr123", "abrah@example.com");
                user.DisplayUser();

                PaymentProcessor paymentProcessor = new PaymentProcessor();
                paymentProcessor.ProcessOrder();
                paymentProcessor.CancelOrder();

                ShippingProcessor shippingProcessor = new ShippingProcessor();
                shippingProcessor.ProcessOrder();
                shippingProcessor.CancelOrder();


            }
        }
    }