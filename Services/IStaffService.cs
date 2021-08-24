using System.Collections.Generic;

namespace MercedesShowRoom
{
    interface IStaffService
    {
        bool Add(Staff staff);
        bool Edit(int id);
        bool Remove(int id);
        bool Check(int id, string pass);
        List<Staff> Get();
    }
}