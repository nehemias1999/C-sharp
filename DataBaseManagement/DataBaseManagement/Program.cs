namespace DataBaseManagement.Models
{

    class Program
    {
        public static void Main(string[] args)
        {

            var customers = new Customers();

            // SELECT
            var listCustomers = customers.getData();

            foreach ( var customer in listCustomers ) 
            { 
                Console.WriteLine(" customer_id = " + customer.customer_id + ", first_name = " + customer.first_name + ", last_name = " + customer.last_name + ", phone = " + customer.phone + ", address = " + customer.address);
            }

            // INSERT
            var newCustomer = new Customer(1, "first_name", "last_name", "phone", "address");

            customers.addData(newCustomer);
            
            // UPDATE
            var updateCustomer = new Customer(1, "first_name", "last_name", "phone", "address");

            var customer_id = 2;

            customers.updateData(updateCustomer, 4);
            
            // DELETE
            customers.removeData(customer_id);
           
        }

    }


}
