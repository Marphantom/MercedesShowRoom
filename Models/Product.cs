using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace MercedesShowRoom
{
    class Product
    {
        public int productId { get; set; }
        public string productSeries { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string receipt { get; set; }

        public override string ToString()
        {
            return string.Format($"|ID: {productId,2}||Series: {productSeries,5}||Name: {productName,-10}| |Price: {price,-10}||Receipt: {receipt,5}|");
        }
    }
    class ProductList
    {
        public List<Product> products { get; set; }
    }
}
