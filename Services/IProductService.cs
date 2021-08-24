using System.Collections.Generic;

namespace MercedesShowRoom
{
    interface IProductService
    {
        bool Add(Product product);
        bool Edit(int id);
        bool Remove(int id);
        List<Product> Get();
    }
}