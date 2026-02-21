   public class InventoryView
    {
        private InventoryService service = new InventoryService();

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===== INVENTORY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        service.ResetInventory();
                        Console.WriteLine("Inventory has been reset.");
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            string[,] products = service.GetInventory();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
            }
        }

        private void UpdateStock()
        {
            string[,] products = service.GetInventory();

            Console.WriteLine("\nSelect Product to Update:");
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]}");
            }

            Console.Write("Enter product number: ");
            if (int.TryParse(Console.ReadLine(), out int productChoice))
            {
                int index = productChoice - 1;

                Console.Write("Enter new stock quantity: ");
                string newStock = Console.ReadLine();

                service.UpdateStock(index, newStock);
                Console.WriteLine("Stock updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
