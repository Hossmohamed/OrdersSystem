using AutoMapper;
using OrderUpdate.DTO;
using OrderUpdate.Manager;
using OrderUpdate.Models;
using System.Text.Json;

namespace order.Manager
{
    public class OrderDummy : Iorder
    {

        IMapper mapper;

        public OrderDummy(IMapper _mapper)

        {
            mapper = _mapper;
            orders = new List<Orders>();
        }

        List<Orders> orders;
       // static List<OrderDTO> or = new List<OrderDTO>();


        public Orders Add(OrderDTO order)
        {
            var result = mapper.Map<Orders>(order);
            string Orderpath = "order.json";

            #region create and append order
  
            //// Read existing data
            string existingData = File.ReadAllText(Orderpath);

            // Deserialize existing data into a list of Orders
            List<Orders> existingOrder = JsonSerializer.Deserialize<List<Orders>>(existingData);

            // Add the new order to the existing list
            existingOrder.Add(result);

            // Serialize the updated list and write it back to the file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string updatedData = JsonSerializer.Serialize(existingOrder, options);
            File.WriteAllText(Orderpath, updatedData);
            #endregion

            #region check if orderid is exist
             if(existingOrder.Any(o=>o.ID==result.ID))
            {

                throw new Exception("this ID already exist");
            }
            #endregion

            #region initialize orderID
            int maxOrderID = existingOrder.Max(existing => existing.ID);
            result.ID = maxOrderID + 1;

            #endregion
            return result;
        }

        public List<OrderDTO> getall()
        {
            string subOrderPath = "suborder.json";
            var subOrderFullPath = Path.GetFullPath(subOrderPath);
            if (!File.Exists(subOrderFullPath))
                throw new Exception("File not exists");
            string str1 = File.ReadAllText(subOrderPath);
            List<SubOrders> subOrder = JsonSerializer.Deserialize<List<SubOrders>>(str1);
            var result1 = mapper.Map<List<SubOrderDTO>>(subOrder);
            //////////////////////
            string orderPath = "order.json";
            var orderFullPath = Path.GetFullPath(orderPath);
            string str = File.ReadAllText(orderPath);
            List<Orders> Order = JsonSerializer.Deserialize<List<Orders>>(str);

            List<OrderDTO> result = mapper.Map<List<OrderDTO>>(Order);
            foreach (var item in result)
            {
                item.subOrder=result1.Where(s=>s.OrderId==item.OrderID).ToList();
                
            }


            //string orderPath = "order.json";
            //string orderJson = File.ReadAllText(orderPath);

            //string subOrderPath = "suborder.json";
            //string subOrderJson = File.ReadAllText(subOrderPath);

            //List<Orders> orders = JsonSerializer.Deserialize<List<Orders>>(orderJson);
            //List<SubOrders> subOrders = JsonSerializer.Deserialize<List<SubOrders>>(subOrderJson);
            //var orderDTOs = mapper.Map<List<OrderDTO>>(orders);
            //var subOrderDTOs = mapper.Map<List<SubOrderDTO>>(subOrders);
            //foreach (var orderDTO in orderDTOs)
            //{
            //    orderDTO.subOrder = subOrderDTOs.Where(s => s.OrderId == orderDTO.OrderID).ToList();
            //}

            return result;
        }
    }

    }
