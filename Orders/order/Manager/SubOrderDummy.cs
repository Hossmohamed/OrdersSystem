// Bug: order doesn't return suborders-- Done
// path : config not hard coded
// orders & suborders list should restore from file at CTOR Done
// refresh button(done)

// domain integrity (identity)Done
// UI client can we plot grid based on JSON only ?
// remove reference of DTOs from UI project
using AutoMapper;
using OrderUpdate.DTO;
using OrderUpdate.Manager;
using OrderUpdate.Models;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace order.Manager
{
    public class SubOrderDummy : IsubOrder
    {
        IMapper mapper;

        public SubOrderDummy(IMapper _mapper)
        {
            mapper = _mapper;

        }

        public SubOrders Add(SubOrderDTO suborder)
        {
            var result = mapper.Map<SubOrders>(suborder);


            string subOrederPath = "suborder.json";
            string Orderpath = "order.json";

            #region append data in file
         
            //// Read existing data
            string existingData = File.ReadAllText(subOrederPath);
            // Deserialize existing data into a list of Orders

            List<SubOrders> existingSubOrder = JsonSerializer.Deserialize<List<SubOrders>>(existingData);
            // Add the new order to the existing list

            existingSubOrder.Add(result);
            // Serialize the updated list and write it back to the file

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string updatedData = JsonSerializer.Serialize(existingSubOrder, options);
            File.WriteAllText(subOrederPath, updatedData);
            #endregion
            #region return order and check existence of id
            string existingOrderData = File.ReadAllText(Orderpath);

            // Deserialize existing data into a list of Orders
            List<Orders> existingOrder = JsonSerializer.Deserialize<List<Orders>>(existingOrderData);

            if (result.OrderID >= 0 || !(existingOrder.Any(o => o.ID == result.OrderID)) || existingSubOrder.Any(s => s.SuborderID == result.SuborderID))
            {
                throw new Exception("this id <1 or donot match with any orderID or this subOrderID already exist");
            }


            #endregion
            #region initialize orderID
            int maxOrderID = existingOrder.Max(existing => existing.ID);
            result.SuborderID = maxOrderID + 1;

            #endregion
            return result;
        }

        public List<SubOrderDTO> getall()
        {
            string path = "suborder.json";
            string str = File.ReadAllText(path);
            List<SubOrders> subOrder = JsonSerializer.Deserialize<List<SubOrders>>(str);
            var result = mapper.Map<List<SubOrderDTO>>(subOrder);

            return result;
        }
    }
}
