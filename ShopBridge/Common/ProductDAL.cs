using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.Common
{
    public class ProductDAL
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopBridge;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlCon = null;


        public async Task<DataTable> getProducts()
        {
            DataTable result = new DataTable();
            try
            {
                await Task.Run(() =>
                {
                    using (sqlCon = new SqlConnection(connectionString))
                    {

                        SqlCommand cmd = new SqlCommand("sp_GetAllProducts", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(result);

                    }
                });
            }
            catch (Exception ex)
            {
                addErrorData(ex.Message, ex.StackTrace);
            }
            return result;
        }

        public async Task<DataTable> getProduct(int productId)
        {
            DataTable result = new DataTable();
            try
            {
                await Task.Run(() =>
                {

                    using (sqlCon = new SqlConnection(connectionString))
                    {

                        SqlCommand cmd = new SqlCommand("sp_getProduct", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@productId", SqlDbType.NVarChar).Value = productId;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(result);

                    }
                });
            }
            catch (Exception ex)
            {
                addErrorData(ex.Message, ex.StackTrace);
            }
            return result;
        }
        public async Task<int> addProduct(Product product)
        {
            int result = 0;
            try
            {
                await Task.Run(() =>
                {
                    using (sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_AddProduct", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = product.productName;
                        sql_cmnd.Parameters.AddWithValue("@ProductDescription", SqlDbType.NVarChar).Value = product.productDescription;
                        sql_cmnd.Parameters.AddWithValue("@ProductPrice", SqlDbType.Int).Value = product.productPrice;
                        sql_cmnd.Parameters.AddWithValue("@Quantity", SqlDbType.Int).Value = product.quantityAvailable;
                        result = (int)sql_cmnd.ExecuteScalar();
                        sqlCon.Close();
                    }
                });
            }
            catch (Exception ex)
            {
                addErrorData(ex.Message, ex.StackTrace);
            }
            return result;
        }

        public async Task<int> updateProduct(Product product)
        {
            int result = 0;
            try
            {
                await Task.Run(() =>
                {
                    using (sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_updateProduct", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@productId", SqlDbType.NVarChar).Value = product.productId;
                        sql_cmnd.Parameters.AddWithValue("@productName", SqlDbType.NVarChar).Value = (string.IsNullOrEmpty(product.productName)) ? string.Empty : product.productName;
                        sql_cmnd.Parameters.AddWithValue("@productDesc", SqlDbType.NVarChar).Value = (string.IsNullOrEmpty(product.productDescription)) ? string.Empty : product.productDescription;
                        sql_cmnd.Parameters.AddWithValue("@productPrice", SqlDbType.Int).Value = product.productPrice;
                        sql_cmnd.Parameters.AddWithValue("@availableQuantity", SqlDbType.Int).Value = product.quantityAvailable;
                        result = (int)sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();
                    }

                });
            }
            catch (Exception ex)
            {
                addErrorData(ex.Message, ex.StackTrace);
            }

            return result;
        }

        public async Task<int> deleteProduct(int productId)
        {
            int result = 0;
            try
            {
                await Task.Run(() =>
                {
                    using (sqlCon = new SqlConnection(connectionString))
                    {

                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("sp_deleteProduct", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@productId", SqlDbType.NVarChar).Value = productId;
                        result = (int)cmd.ExecuteNonQuery();

                    }

                });
            }
            catch (Exception ex)
            {
                addErrorData(ex.Message, ex.StackTrace);
            }

            return result;
        }

        public void addErrorData(string errorMessage, string stackTrace)
        {
            try
            {
                using (sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("sp_InsertErrorLogs", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@ErrorMessage", SqlDbType.NVarChar).Value = errorMessage;
                    sql_cmnd.Parameters.AddWithValue("@ErrorLocation", SqlDbType.NVarChar).Value = stackTrace;
                    sql_cmnd.ExecuteScalar();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                addErrorData(ex.Message, ex.StackTrace);
            }
        }

    }
}