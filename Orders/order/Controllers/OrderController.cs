using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Models;
using OrderUpdate.DTO;
using OrderUpdate.Manager;
using OrderUpdate.Models;
using System.Linq;
using System.Threading.Tasks;


namespace orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        Iorder iorder;
        IsubOrder suborder;
        Context con;

        public OrderController(Iorder _iorder, IsubOrder _suborder, Context _con)
        {
            iorder = _iorder;
            suborder = _suborder;
            con = _con;

        }

        [HttpGet("all")]
        public ActionResult<List<OrderDTO>> getAll()
        {
            return iorder.getall();
        }




        [HttpPost("add")]
        public ActionResult add(OrderDTO orders)
        {

            var or = iorder.Add(orders);
            return Created("url", or);

        }




        [HttpGet("allsuborder")]
        public ActionResult<List<SubOrderDTO>> getAllsuborder()
        {
            return suborder.getall();
        }




        [HttpPost("addsuborder")]
        public ActionResult addsuborder(SubOrderDTO suborders)
        {

            var sub = suborder.Add(suborders);

            return Created("url", sub);

        }


        //public async Task<ActionResult<List<OrderViewModel>>> GetOrdersByIds([FromQuery] List<int> orderIds)
        //{
        //    if (orderIds == null )
        //    {
        //        return BadRequest("No order IDs provided.");
        //    }

        //    var orderViewModels = await OrganizeDataAsync(orderIds);

        //    if (orderViewModels == null || !orderViewModels.Any())
        //    {
        //        return NotFound("No orders found for the provided IDs.");
        //    }

        //    return Ok(orderViewModels);
        //}
        [HttpGet("byids")]

        public ActionResult<List<OrderDTO>> OrganizeData([FromQuery] List<int> orderIds)
        {
            var orders = iorder.getall()
                .Where(order => orderIds.Contains(order.OrderID))
                .ToList();

            var suborders = suborder.getall()
                .Where(suborder => orderIds.Contains(suborder.OrderId))
                .ToList();

            //var orderViewModels = orders.Select(order => new OrderViewModel
            //{
            //    Orders = orders.ToList(), 
            //    SubOrders = suborders.Where(suborder => suborder.OrderId == order.OrderId).ToList()
            //}).ToList();

            return orders;
            }



            //[HttpGet("getViewModel")]
            //public ActionResult<List<OrderViewModel>> GetViewModel([FromQuery] List<int> orderIDs)
            //{
            //    if (orderIDs == null || !orderIDs.Any())
            //    {

            //        return BadRequest("No orderIDs provided.");
            //    }


            //    var orderViewModels = con.OrderViewModels
            //     .Where(o => orderIDs.Contains(o.OrderViewModelID)) // Assuming OrderViewModelID matches orderIDs
            //     .ToList();


            //    return orderViewModels;
            //}



            //[HttpPost]
            //public ActionResult Add(Orders order) 
            //{

            // if(ModelState.IsValid) 
            //    {
            //        try
            //        {
            //            con.Orders.Add(order);
            //            con.SaveChanges();
            //            return Ok(order);
            //        }
            //        catch (Exception ex) 
            //        {
            //          return BadRequest(ex.Message);
            //        }
            //    }
            //        return BadRequest();


            //}
        } 
}
