using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseManagement.Models
{
    class Customer
    {

        public int customer_id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String phone { get; set; }
        public String address { get; set; }

        public Customer(int customer_id, String first_name, String last_name, String phone, String address)
        {
            this.customer_id = customer_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone = phone;
            this.address = address;
        }

    }
}
