using Microsoft.EntityFrameworkCore;
using OrderUpdate.Manager;
using OrderUpdate.Models;
using System.Text.Json.Serialization;

namespace Order.Models
{
    [Keyless]
    public class OrderViewModel
    {

        [JsonIgnore]
        public List<Orders> Orders { get; set; } // List of Orders

        [JsonIgnore]
        public List<SubOrders> SubOrders { get; set; } // List of SubOrders
    }
}
