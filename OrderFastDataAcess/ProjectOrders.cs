using OrderFastModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCommon;
using System.Data;
using System.Security.Cryptography;


namespace OrderFast.DataAcess
{
    public class ProjectOrders : InterfaceProjectOrder
    {
        public List<Orders> GetOrders()
        {
            DataTable dataTable = Get.GetResultDataTableBySql("GetOrders");
            List<Orders> order = new List<Orders>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                order.Add(new Orders
                {
                    OrderId = Convert.ToInt32(dataRow["OrderId"]),
                    OrderDate = Convert.ToDateTime(dataRow["OrderDate"]),
                    OrderedBy = Convert.ToString(dataRow["OrderedBy"]),
                    TotalBill = Convert.ToInt16(dataRow["TotalBill"])

                });
            }
            return order;

        }
        public Orders GetOrderById(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            });
            DataTable dataTable = Get.GetResultDataTableBySql("GetOrderById @OrderId", parameters);
            Orders order = new Orders();
            foreach (DataRow Item in dataTable.Rows)
            {
                order.OrderId = Convert.ToInt32(Item[0]);
                order.OrderDate = Convert.ToDateTime(Item[1]);
                order.OrderedBy = Convert.ToString(Item[2]);
                order.TotalBill = Convert.ToDouble(Item[3]);

            }
            return order;


        }
        public int AddOrder(Orders o)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = o.OrderDate
            }) ;
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderBy",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = o.OrderedBy
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@TotalBIll",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = o.TotalBill
            });
            string query = "AddOrder @OrderDate,@OrderBy,@TotalBIll ";
            return Get.ExecuteNonQuerySql(query, parameters);

        }       
        public int UpdateOrder(Orders o,int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = o.OrderDate
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderBy",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = o.OrderedBy
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@TotalBIll",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = o.TotalBill
            });
            string query = "UpdateOrder @OrderId,@OrderDate,@OrderBy,@TotalBIll";
            return Get.ExecuteNonQuerySql(query, parameters);
        }
        public int DeleteOrder(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@OrderId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            });
            return Get.ExecuteNonQuerySql("DeleteOrder @OrderId", parameters);
        }


    }
}