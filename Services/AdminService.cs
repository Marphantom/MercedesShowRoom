using System;

namespace MercedesShowRoom
{
    class AdminService
    {
        private readonly StaffService staffService;
        private readonly ProductService productService;

        public AdminService()
        {
            staffService = new StaffService();
            productService = new ProductService();

        }

        #region Staff methods
        public bool CreateStaff(Staff staff)
        {
            return staffService.Add(staff);
        }

        public bool EditStaff(int id)
        {
            return staffService.Edit(id);
        }

        public bool RemoveStaff(int id)
        {
            return staffService.Remove(id);
        }

        public void ShowStaff()
        {
            foreach (Staff staff in staffService.Get())
            {
                Console.WriteLine(staff.ToString());
            }
        }

        public bool LoginId(int id, string pass)
        {
            return staffService.Check(id, pass);
        }
        
        #endregion

        #region Product methods
        public bool CreateProduct(Product product)
        {
            return productService.Add(product);
        }

        public bool EditProduct(int id)
        {
            return productService.Edit(id);
        }

        public bool RemoveProduct(int id)
        {
            return productService.Remove(id);
        }

        public void ShowProduct()
        {
            foreach (Product pd in productService.Get())
            {
                Console.WriteLine(pd.ToString());
            }
        }

        public bool CreateBill()
        {
            return productService.AddBill();
        }
        public void ShowBill()
        {
            foreach(Bill bill in productService.GetBills())
            {
                Console.WriteLine(bill.ToString());
            }
        }
        #endregion
    }
}