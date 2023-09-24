using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrderUpdate.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        public string ? Ordertype { get; set; }
        public string? OrderStatus { get; set; }
        public int OrderQuantity { get; set; }
        [JsonIgnore]
        public virtual List<SubOrders> SubOrders { get; set; } = new List<SubOrders>();

    }
}
