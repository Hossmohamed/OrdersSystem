using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrderUpdate.Models
{
    public class SubOrders
    {
        [Key]
        public int SuborderID { get; set; }
        public int SuborderQuantity { get; set; }
        public string Subordertype { get; set; } = string.Empty;
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        [JsonIgnore]
        public Orders? Orders { get; set; }
         
           
          
    }
}