using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GroupedOrder
{
    public string Client { get; set; }
    public DateTime Date { get; set; }
    public double Total { get; set; }
    public bool Shipped { get; set; }

    public GroupedOrder(string client, DateTime date, double total)
    {
        Client = client;
        Date = date;
        Total = total;
    }

    public GroupedOrder(string client, DateTime date, double total, bool shipped)
    {
        Client = client;
        Date = date;
        Total = total;
        Shipped = shipped;
    }
}