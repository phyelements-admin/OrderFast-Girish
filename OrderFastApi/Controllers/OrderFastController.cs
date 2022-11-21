using DBCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFast.DataAcess;
using OrderFastModels;
using DBCommon;
using System.Data.SqlClient;

namespace OrderFastApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderFastController : ControllerBase
    {
        InterfaceProjectOrder porders = new ProjectOrders();
        [Route("getorder")]
        [HttpGet]
        public List<Orders> Get()
        {
            return porders.GetOrders();
            
        }
        [Route("getbyid/{id}")]
        [HttpGet]
        public Orders Get(int id)
        {
            return porders.GetOrderById(id);

        }
        [Route("addorder")]
        [HttpPost]
        public int Post(Orders o)
        {
            return porders.AddOrder(o);
        }

        [Route("updateorder/{id}")]
        [HttpPut]
        public int Put(Orders o, int id)
        {
            return porders.UpdateOrder(o,id);
        }
        [Route("deleteorder/{id}")]
        [HttpDelete]
        public int Delete(int id)
        {
            return porders.DeleteOrder(id);
        }
    }
}
