using System.ComponentModel;

namespace OrderUpdate.DTO
{
    public class SubOrderDTO
    {
        [DisplayName("subOrder ID")]
        public int SuborderId { get; set; }

        [DisplayName("SubOrder Type")]

        public string subordertype { get; set; } = string.Empty;

        [DisplayName("SubOrder Qantity")]
        public int suborderQuantity { get; set; }


        [DisplayName("Executed Qantity")]
        public int ExecutedQuantity { get; set; }

        public int OrderId { get; set; }
    }
}
