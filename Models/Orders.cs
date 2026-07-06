using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public string Productid { get; set; }

        public string Customerid { get; set; }

        public string? ProductName { get; set; }

        public string? Category { get; set; }

        public string? Region { get; set; }

        public DateTime? SalesDate { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ShippingCost { get; set; }
        public string? PaymentMethod { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerMail { get; set; }

        public string? CustomerAddress { get; set; }
    }
}