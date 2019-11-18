using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class CustomerRepository : IRepository<Customer, string>
    {
        static List<Customer> customerList;
        public CustomerRepository()
        {
            if (customerList == null)
            {
                customerList = new List<Customer>();
                AddItemsToList();
            }
        }
        private void AddItemsToList()
        {
            Customer c1 = new Customer
            {
                CustomerId = "ABCD",
                CompanyName = "Suresh&Ramesh Corportaion",
                ContactName = "Suresh Mehata",
                City = "Bengaluru",
                Country = "India"
            };
            customerList.Add(c1);
            customerList.Add(new Customer
            {
                CustomerId = "xyz",
                CompanyName = "Sneha Corportaion",
                ContactName = "Rakshitha",
                City = "Bengaluru",
                Country = "India"



            });
            customerList.Add(new Customer
            {
                CustomerId = "LMNO",
                CompanyName = "Manju&Vijaya Corportaion",
                ContactName = "Chitra",
                City = "Mysore",
                Country = "India"
            });
        }

        public IQueryable<Customer> GetAll()
        {
            var query = from item in customerList select item;
            return query.AsQueryable();
        }

        public Customer GetDetails(string identity)
        {
            //customerList.First(c => c); // throw exception is not found.
            return customerList.FirstOrDefault(c => c.CustomerId.Equals(identity));
        }
        public void CreateNew(Customer item)
        {
           if(item !=null)
            {
                customerList.Add(item);
            }
        }

        public void Delete(string identity)
        {
            if(!string.IsNullOrEmpty(identity))
            {
                customerList.RemoveAll(c => c.CustomerId == identity);
            }
        }

       

        public void Update(Customer item)
        {
           if(item !=null)
            {
                customerList.RemoveAll(c => c.CustomerId == item.CustomerId);
                customerList.Add(item);
            }
        }
    }
}