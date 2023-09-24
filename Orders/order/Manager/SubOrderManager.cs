using OrderUpdate.DTO;
using OrderUpdate.Models;

namespace OrderUpdate.Manager
{
    public class SubOrderManager : IsubOrder
    {
        Context context;

        public SubOrderManager(Context _context)
        {
            context = _context;
        }

        public SubOrders Add(SubOrderDTO order)
        {
            var subOrder = new SubOrders();

            //order.SuborderId = subOrder.SuborderID;
            //order.OrderId = subOrder.OrderID;
            //order.suborderQuantity = subOrder.SuborderQuantity;
            //order.subordertype = subOrder.Subordertype;

            ////////////////////////////////////////////////////////
         // subOrder.SuborderID = order.SuborderId;
            subOrder.SuborderQuantity = order.suborderQuantity;
            subOrder.Subordertype = order.subordertype;
            subOrder.OrderID = order.OrderId;
             



            context.SubOrders.Add(subOrder);
            context.SaveChanges();
            return subOrder;
        }

        public List<SubOrderDTO> getall()
        {
            var suborder = context.SubOrders.ToList();
            List<SubOrderDTO> subOrderDtos = new List<SubOrderDTO>();
            foreach (var item in suborder)
            {
                SubOrderDTO subOrderDto = new SubOrderDTO();
                subOrderDto.SuborderId = item.SuborderID;
                subOrderDto.OrderId = item.OrderID;
                subOrderDto.suborderQuantity = item.SuborderQuantity;
                subOrderDto.subordertype = item.Subordertype;

                subOrderDtos.Add(subOrderDto);

            }
            return subOrderDtos;
        }
    }
}
