using OrderUpdate.DTO;
using OrderUpdate.Models;

namespace OrderUpdate.Manager
{
    public interface IsubOrder
    {
        public List<SubOrderDTO> getall();
        public SubOrders Add(SubOrderDTO order);
    }
}
