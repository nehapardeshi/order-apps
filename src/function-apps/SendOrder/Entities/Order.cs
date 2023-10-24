using System;
using System.Collections.Generic;

namespace SendOrder.Entities;

public class Order
{
    public string OrderNumber { get; set; }
    public string CustomerNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderLine> OrderLines { get; set; }
}
