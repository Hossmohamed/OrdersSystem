using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderUpdate.DTO;
using OrderUpdate.Models;

namespace OrderUpdate.Manager
{
    public class OrderManager : Iorder
    {
        Context context;
        IsubOrder subOrder;
        IMapper mapper;

        public OrderManager(Context _context, IsubOrder _subOrder, IMapper _mapper)

        {
            context = _context;
            subOrder = _subOrder;
            mapper = _mapper;
        }

        public Orders Add(OrderDTO order)
        {
            //var _order = new Orders();

            //_order.ID = order.OrderID;
            //_order.OrderStatus = order.OrderStatus;
            //_order.OrderQuantity = order.OrderQuantity;
            //_order.Ordertype = order.Ordertype;

            var result = mapper.Map<Orders>(order);


            context.Orders.Add(result);
            context.SaveChanges();
            return result;
        }

        public List<OrderDTO> getall()
        {

            var order = context.Orders.Include(o => o.SubOrders).ToList();

            var result=mapper.Map<List<OrderDTO>>(order);


            #region MyRegion
            //List<OrderDTO> orderDtos = new List<OrderDTO>();
            //foreach (var item in order)
            //{
            //    OrderDTO dto = new OrderDTO();

            //    dto.OrderId = item.ID;
            //    dto.Ordertype = item.Ordertype;
            //    dto.OrderStatus = item.OrderStatus;

            //    dto.OrderQuantity = item.OrderQuantity;
            //    //  var suborders = dto.subOrder = new List<SubOrderDTO>();//auto mapper= item.SubOrders;



            //    #region foreach
            //    //foreach (var s in item.SubOrders)
            //    //{
            //    //    suborders.Add(new SubOrderDTO
            //    //    {
            //    //        SuborderId = s.SuborderID,
            //    //        suborderQuantity = s.SuborderQuantity,
            //    //        ExecutedQuantity = s.SuborderQuantity / 2,
            //    //        subordertype = s.Subordertype
            //    //    });

            //    //} 
            //    #endregion

            //    orderDtos.Add(dto);
            //} 
            #endregion
            return result;
        }
    }
}
#region select

//    //using select
//    dto.subOrder=item.SubOrders.
//        Select(s=>new SubOrderDTO
//        { SuborderId=s.SuborderID,suborderQuantity=s.SuborderQuantity
//        ,ExecutedQuantity=s.SuborderQuantity/2,
//            subordertype=s.Subordertype}).ToList(); 
#endregion