using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MercedesShowRoom
{
    class ProductService : BaseService, IProductService
    {
        private string fileName = "product.json";
        
        private ProductList productList = new ProductList();
        private string fileBillName = "bill.json";
        private BillList billList = new BillList();
        public ProductService()
        {
            productList = FileHelper.ReadFile<ProductList>(Path.Combine(path, fileName));
            billList = FileHelper.ReadFile<BillList>(Path.Combine(path,fileBillName));
        }
        public bool Add(Product product)
        {
            int productID = productList.products.Max(s => s.productId) + 1;
            product.productId = productID;
            productList.products.Add(product);
            FileHelper.WriteFile<ProductList>(Path.Combine(path, fileName), productList);
            return true;
        }

        public bool Edit(int id)
        {
            foreach (Product pd in productList.products)
            {
                if (pd.productId.Equals(id))
                {
                    Console.Write("Enter product series: ");
                    pd.productSeries = Console.ReadLine();
                    Console.Write("Enter product name: ");
                    pd.productName = Console.ReadLine();
                    Console.Write("Enter price: ");
                    pd.price = double.Parse(Console.ReadLine());
                    Console.Write("Enter receipt: ");
                    pd.receipt = Console.ReadLine();
                    break;
                }
            }
            FileHelper.WriteFile<ProductList>(Path.Combine(path, fileName), productList);
            return true;
        }

        public bool Remove(int id)
        {
            foreach (Product pd in productList.products)
            {
                if (pd.productId.Equals(id))
                {
                    productList.products.Remove(pd);
                    break;
                }
            }
            FileHelper.WriteFile<ProductList>(Path.Combine(path, fileName), productList);
            return true;
        }
        public List<Product> Get()
        {
            return productList.products;
        }

         public bool AddBill()
        {
            int BillID = billList.bills.Max(s => s.billId) + 1;
            DateTime dateBill = DateTime.Now;
            Console.Write("Enter customer name: ");
            string nameCus = Console.ReadLine();
            Console.Write("Enter customer phonenumber: ");
            string phoneCus = Console.ReadLine();
            Console.Write("Enter customer adress: ");
            string adressCus = Console.ReadLine();
            Console.Write("Enter series: ");
            string series = Console.ReadLine();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter date: ");
            string date = Console.ReadLine();
            foreach(Product pd in productList.products)
            {
                if(pd.productSeries.Equals(series) && pd.productName.Equals(name) && pd.receipt.Equals(date))
                {
                    Console.WriteLine("Do you want to buy this product?");
                    Console.Write("Y/");
                    Console.Write("N ");
                    var select = Console.Read();
                    switch (select)
                    {
                        case 121:
                            {
                                Bill bill = new Bill()
                                {
                                    billId = BillID,
                                    dateBill = dateBill,
                                    nameCus = nameCus,
                                    phoneCus = phoneCus,
                                    adressCus = adressCus,
                                    productSeries = pd.productSeries,
                                    productName = pd.productName,
                                    price = pd.price
                                };
                                billList.bills.Add(bill);
                                
                                productList.products.Remove(pd);
                                
                                break;
                            }
                        case 110:
                            {

                                break;
                            }
                    }
                    break;
                }
            }
            FileHelper.WriteFile<BillList>(Path.Combine(path, fileBillName), billList);
            FileHelper.WriteFile<ProductList>(Path.Combine(path, fileName), productList);
            return true;
        }
        public List<Bill> GetBills()
        {
            return billList.bills;
        }
    }
}
