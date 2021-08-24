using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace MercedesShowRoom
{
    class Staff
    {
        public int staffId { get; set; }
        public string staffName { get; set; }
        public string staffRole { get; set; }
        public string staffPhone { get; set; }
        public string passWord { get; set; }
        
        public override string ToString()
        {
            return string.Format($"|ID: {staffId,3}| |Name: {staffName,-35}| |Roll: {staffRole, -4}| |Phone: {staffPhone, -10}|");
        }
    }

    class StaffList
    {
        public List<Staff> staffs { get; set; }
    }
}