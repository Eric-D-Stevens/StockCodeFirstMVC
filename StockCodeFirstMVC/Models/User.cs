using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace StockCodeFirstMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public double PricePaid { get; set; }
        public DateTime DateAndTime { get; set; }
    }

    public class StockContext : DbContext
    {
        public StockContext() : base("StockCodeFirstMVC")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}