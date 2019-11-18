using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class NorthwindContext:System.Data.Entity.DbContext
    {
        //Define a database set property whose name should match with the physical table name
        //NOTE: the property name should be plural of the Conceptual class

        public System.Data.Entity.DbSet<MvcApplication.Models.Product>Products { get; set; }

        //Next task is to create a connection string with the "NorthwindContext" name.
        //This
    }
}