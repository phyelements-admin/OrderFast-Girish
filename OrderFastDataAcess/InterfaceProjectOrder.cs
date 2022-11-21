using OrderFastModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFast.DataAcess
{
    public interface InterfaceProjectOrder
    {
        List<Orders> GetOrders();
        Orders GetOrderById(int id);
        int AddOrder(Orders o);        
        int UpdateOrder(Orders o,int id);
        int DeleteOrder(int id);
    }
}
