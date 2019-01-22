using System;
using System.Collections.Generic;
using System.Web;


public class Order
{
   public int id { get; set; }
   public string clientName { get; set; }
   public string product { get; set; }
   public int amount { get; set; }
   public double price { get; set; }
   public DateTime date { get; set; }
   public bool orderShipped { get; set; }
   public string deliveryAddress { get; set;  }

   public Order(int id, string clientName, string product, int amount, double price, DateTime date, bool orderShipped, string deliveryAddress)
   {
       this.id = id;
       this.clientName = clientName;
       this.product = product;
       this.amount = amount;
       this.price = price;
       this.date = date;
       this.orderShipped = orderShipped;
       this.deliveryAddress = deliveryAddress;
   }

   public Order(string clientName, string product, int amount, double price, DateTime date, bool orderShipped, string deliveryAddress)
   {
       this.clientName = clientName;
       this.product = product;
       this.amount = amount;
       this.price = price;
       this.date = date;
       this.orderShipped = orderShipped;
       this.deliveryAddress = deliveryAddress;
   }


}