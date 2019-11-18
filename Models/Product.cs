using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MvcApplication.Models
{
    public class Product
    {
        /* SQL Server*/
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(50, ErrorMessage = "Category Name cannot exceed 50 chars.")]
        [Display(Name = "Category Name")]
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public  decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
    }
}