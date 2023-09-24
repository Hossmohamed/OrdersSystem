using OrderUpdate.DTO;
using OrderUpdate.Models;

namespace OrderUpdate.Manager
{
    public interface Iorder
    {
        public List<OrderDTO> getall();
        public Orders Add(OrderDTO order);
    }
}
