using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class OrderMasterCollection : BusinessBaseCollection<OrderMaster>
    {
        public static OrderMasterCollection GetAll()
        {
            OrderMasterCollection obj = new OrderMasterCollection();
            obj.MapObjects(new OrderService().OrderGetAll());
            return obj;
        }
        public static OrderMasterCollection getOrderId(int OrderId)
        {
            OrderMasterCollection obj = new OrderMasterCollection();
            obj.MapObjects(new OrderService().OrderGetByOrderId(OrderId));
            return obj;
        }
    }
}
