
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OrderUpdate.DTO
{
    public class OrderDTO
    {
        [DisplayName("Order ID")]
        public int OrderID { get; set; }

        [DisplayName("Order Type")]
        public string Ordertype { get; set; }

        [DisplayName("Order Status")]
        public string OrderStatus { get; set; }

        [DisplayName("Order Quantity")]
        public int OrderQuantity { get; set; }

        [DisplayName("Executed Quantity")]
        public int ExecutedQuantity
        {
            get
            {
                if (subOrder is null || subOrder.Count == 0)
                    return 0;
                else
                    return subOrder.Sum(s => s.ExecutedQuantity);
            }
        }
       
        public List<SubOrderDTO> subOrder { get; set; }
    }
}
