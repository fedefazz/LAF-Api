using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVS.Api.Models
{
    public class Order
    {
        public string name { get; set; }
        public List<OrderIn> value { get; set; }

    }


    public class OrderIn
    {
    public int column { get; set; }
    public string dir { get; set; }

    }
        
}