using System.Collections.Generic;
using System;

namespace MercedesShowRoom
{
    public class Bill
    {
        public int billId { get; set; }
        public DateTime dateBill { get; set; }
        public string nameCus { get; set; }
        public string phoneCus { get; set; }
        public string adressCus { get; set; }
        public string productSeries { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        
        public override string ToString()
        {
            return string.Format($"ID: {billId,2} \n Date bill: {dateBill,5} \n Customer name: {nameCus,30} \n Customer phone: {phoneCus,30} \n Customer adress: {adressCus,30} \n Series: Mercedes-Benz {productSeries,5} {productName,5} \n Price: {price,-6}");
        }
    }

    public class BillList
    {
        public List<Bill> bills { get; set; }
    }
}