using System;

namespace MercedesShowRoom
{
    class Program
    {
        private static AdminService adminService = new AdminService();

        static void Main(string[] args)
        {
            Process();
        }

        public static void BuildMenu(out int selected)
        {
            do
            {
                Console.WriteLine("******* SHOWROOM CAR MERCEDES *******");
                Console.WriteLine("*     1. Login                      *");
                Console.WriteLine("*     2. Exit                       *");
                Console.WriteLine("*************************************");
                Console.Write("Choose a function: ");
                int.TryParse(Console.ReadLine(), out selected);
            }
            while (selected < 1 || selected > 3);
        }

        public static void BuildMenuAdmin(out int choice)
        {
            do
            {
                Console.WriteLine("========== ADMIN ==========");
                Console.WriteLine("||   1. Add staff        ||");
                Console.WriteLine("||   2. Edit staff       ||");
                Console.WriteLine("||   3. Delete staff     ||");
                Console.WriteLine("||   4. Show staff       ||");
                Console.WriteLine("||   5. Add product      ||");
                Console.WriteLine("||   6. Edit product     ||");
                Console.WriteLine("||   7. Delete product   ||");
                Console.WriteLine("||   8. Sale product     ||");
                Console.WriteLine("||   9. Show product     ||");
                Console.WriteLine("||   10. Back            ||");
                Console.WriteLine("===========================");
                Console.Write("Choose a function: ");
                int.TryParse(Console.ReadLine(), out choice);
            }
            while (choice < 1 || choice > 10);
        }
        public static void BuildMenuStaff(out int choice)
        {
            do
            {
                Console.WriteLine("******** STAFF ********");
                Console.WriteLine("*   1. Sale product   *");
                Console.WriteLine("*   2. Show product   *");
                Console.WriteLine("*   3. Back           *");
                Console.WriteLine("***********************");
                Console.Write("Choose a function: ");
                int.TryParse(Console.ReadLine(), out choice);
            }
            while (choice < 1 || choice > 10);
        }

        public static void Process()
        {

            int selected = 0;
            do
            {

                BuildMenu(out selected);
                Console.Clear();
                switch (selected)
                {
                    case 1:
                        {
                            Console.Write("Enter ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter pass: ");
                            string pass = Console.ReadLine();
                            if (adminService.LoginId(id, pass))
                            {
                                int choice = 0;
                                do
                                {
                                    BuildMenuAdmin(out choice);
                                    Console.Clear();
                                    switch (choice)
                                    {
                                        case 1:
                                            {
                                                Console.Write("Enter staff name: ");
                                                var staffName = Console.ReadLine();
                                                Console.Write("Enter roll: ");
                                                var roll = Console.ReadLine();
                                                Console.Write("Enter phone: ");
                                                var phone = Console.ReadLine();
                                                Console.Write("Enter pass: ");
                                                var passWord = Console.ReadLine();
                                                var staff = new Staff()
                                                {
                                                    staffId = 0,
                                                    staffName = staffName,
                                                    staffRole = roll,
                                                    staffPhone = phone,
                                                    passWord = passWord
                                                };

                                                var resultStaff = adminService.CreateStaff(staff);
                                                if (resultStaff)
                                                {
                                                    Console.WriteLine("Staff has been added successfully");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Something went wrong, please contact administrator.");
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Write("Enter ID: ");
                                                id = int.Parse(Console.ReadLine());
                                                adminService.EditStaff(id);
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.Write("Enter ID: ");
                                                id = int.Parse(Console.ReadLine());
                                                adminService.RemoveStaff(id);
                                                break;
                                            }
                                        case 4:
                                            {
                                                adminService.ShowStaff();
                                                break;
                                            }
                                        case 5:
                                            {
                                                Console.Write("Enter product series: ");
                                                var produceSeries = Console.ReadLine();
                                                Console.Write("Enter product name: ");
                                                var productName = Console.ReadLine();
                                                Console.Write("Enter price: ");
                                                var price = double.Parse(Console.ReadLine());
                                                Console.Write("Enter receipt: ");
                                                var receipt = Console.ReadLine();
                                                var product = new Product()
                                                {
                                                    productId = 0,
                                                    productSeries = produceSeries,
                                                    productName = productName,
                                                    price = price,
                                                    receipt = receipt
                                                };
                                                var resultProduct = adminService.CreateProduct(product);
                                                if (resultProduct)
                                                {
                                                    Console.WriteLine("Staff has been added successfully");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Something went wrong, please contact administrator.");
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                Console.Write("Enter product ID: ");
                                                id = int.Parse(Console.ReadLine());
                                                adminService.EditProduct(id);
                                                break;
                                            }
                                        case 7:
                                            {
                                                Console.Write("Enter product ID: ");
                                                id = int.Parse(Console.ReadLine());
                                                adminService.RemoveProduct(id);
                                                break;
                                            }
                                        case 8:
                                            {
                                                adminService.ShowProduct();
                                                adminService.CreateBill();
                                                adminService.ShowBill();
                                                break;
                                            }
                                        case 9:
                                            {
                                                adminService.ShowProduct();
                                                break;
                                            }
                                        case 10:
                                            {
                                                Process();
                                                break;
                                            }
                                    }
                                }
                                while (selected != 10);
                                break;
                            }
                            else
                            {
                                int choice = 0;
                                do
                                {
                                    BuildMenuStaff(out choice);
                                    Console.Clear();
                                    switch (choice)
                                    {
                                        case 1:
                                            {
                                                adminService.ShowProduct();
                                                adminService.CreateBill();
                                                adminService.ShowBill();
                                                break;
                                            }
                                        case 2:
                                            {
                                                adminService.ShowProduct();
                                                break;
                                            }
                                        case 3:
                                            {
                                                Process();
                                                break;
                                            }
                                    }
                                }
                                while (selected != 3);
                                break;
                            }
                        }
                    case 2:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            while (selected != 2);
        }
    }
}
