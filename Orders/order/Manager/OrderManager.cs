using Microsoft.EntityFrameworkCore;
using OrderUpdate.DTO;
using OrderUpdate.Models;

namespace OrderUpdate.Manager
{
    public class OrderManager : Iorder
    {
        Context context;
        IsubOrder subOrder;

        public OrderManager(Context _context, IsubOrder _subOrder)
        {
            context = _context;
            subOrder = _subOrder;
        }

        public Orders Add(OrderDTO order)
        {
            var _order = new Orders();

            _order.ID = order.OrderId;
            _order.OrderStatus = order.OrderStatus;
            _order.OrderQuantity = order.OrderQuantity;
            _order.Ordertype = order.Ordertype;



            context.Orders.Add(_order);
            context.SaveChanges();
            return _order;
        }

        public List<OrderDTO> getall()
        {

            var order = context.Orders.Include(o => o.SubOrders).ToList();
            List<OrderDTO> orderDtos = new List<OrderDTO>();
            foreach (var item in order)
            {
                OrderDTO dto = new OrderDTO();

                dto.OrderId = item.ID;
                dto.Ordertype = item.Ordertype;
                dto.OrderStatus = item.OrderStatus;

                dto.OrderQuantity = item.OrderQuantity;
                var suborders = dto.subOrder = new List<SubOrderDTO>();//auto mapper= item.SubOrders;

                foreach (var s in item.SubOrders)
                {
                    suborders.Add(new SubOrderDTO
                    {
                        SuborderId = s.SuborderID,
                        suborderQuantity = s.SuborderQuantity,
                        ExecutedQuantity = s.SuborderQuantity / 2,
                        subordertype = s.Subordertype
                    });

                }

                orderDtos.Add(dto);
            }
            return orderDtos;
        }
    }
}
