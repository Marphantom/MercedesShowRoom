using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MercedesShowRoom
{
    class StaffService : BaseService, IStaffService
    {
        private string fileName = "staff.json";
        private StaffList staffList = new StaffList();
        public StaffService()
        {
            staffList = FileHelper.ReadFile<StaffList>(Path.Combine(path, fileName));
        }

        public bool Add(Staff staff)
        {
            int staffId = staffList.staffs.Max(s => s.staffId) + 1;
            staff.staffId = staffId;
            staffList.staffs.Add(staff);
            FileHelper.WriteFile<StaffList>(Path.Combine(path, fileName), staffList);
            return true;
        }

        public bool Edit(int id)
        {
            foreach (Staff st in staffList.staffs)
            {
                if (st.staffId.Equals(id))
                {
                    Console.Write("Enter staff name: ");
                    st.staffName = Console.ReadLine();
                    Console.Write("Enter roll: ");
                    st.staffRole = Console.ReadLine();
                    Console.Write("Enter phone: ");
                    st.staffPhone = Console.ReadLine();
                    break;
                }
            }
            FileHelper.WriteFile<StaffList>(Path.Combine(path, fileName), staffList);
            return true;
        }

        public bool Remove(int id)
        {
            foreach (Staff st in staffList.staffs)
            {
                if (st.staffId.Equals(id))
                {
                    staffList.staffs.Remove(st);
                    break;
                }
            }
            FileHelper.WriteFile<StaffList>(Path.Combine(path, fileName), staffList);
            return true;
        }

        public bool Check(int id, string pass)
        {
            bool check = false;
            foreach (Staff st in staffList.staffs)
            {
                if (st.staffId.Equals(id))
                {
                    if (st.passWord.Equals(pass))
                    {
                        if (st.staffRole.Equals("admin"))
                        {
                            check = true;
                            break;
                        }
                        else 
                        {
                            check = false;
                        }
                    }
                    break;
                }
            }
            return check;
        }

        public List<Staff> Get()
        {
            return staffList.staffs;
        }
    }
}