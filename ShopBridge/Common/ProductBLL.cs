using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.Common
{
    public class ProductBLL
    {
        ProductDAL objDAL = new ProductDAL();

        public async Task<List<Product>> getProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                DataTable result = null;

                result = await objDAL.getProducts();
                if (result != null)
                {
                    foreach (DataRow dr in result.Rows)
                    {
                        Product pr = new Product();
                        pr.productId = Convert.ToInt32(dr[0].ToString());
                        pr.productName = dr[1].ToString();
                        pr.productDescription = dr[2].ToString();
                        pr.productPrice = Convert.ToInt32(dr[3].ToString());
                        pr.quantityAvailable = Convert.ToInt32(dr[4].ToString());
                        products.Add(pr);
                    }
                }
            }
            catch (Exception ex)
            {
                objDAL.addErrorData(ex.Message, ex.StackTrace);

            }

            return products;
        }

        public async Task<Product> getProduct(int productId)
        {
            DataTable result = null;
            Product product = null;

            try
            {
                result = await objDAL.getProduct(productId);
                if (result != null)
                {
                    foreach (DataRow dr in result.Rows)
                    {
                        product = new Product();
                        product.productId = Convert.ToInt32(dr[0].ToString());
                        product.productName = dr[1].ToString();
                        product.productDescription = dr[2].ToString();
                        product.productPrice = Convert.ToInt32(dr[3].ToString());
                        product.quantityAvailable = Convert.ToInt32(dr[4].ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                objDAL.addErrorData(ex.Message, ex.StackTrace);

            }
            return product;
        }
        public async Task<int> addProduct(Product product)
        {
            try
            {
                return await objDAL.addProduct(product);
            }
            catch (Exception ex)
            {
                objDAL.addErrorData(ex.Message, ex.StackTrace);
                return 0;
            }
        }

        public async Task<int> updateProduct(Product product)
        {
            try
            {
                return await objDAL.updateProduct(product);
            }
            catch (Exception ex)
            {
                objDAL.addErrorData(ex.Message, ex.StackTrace);
                return 0;
            }
        }

        public async Task<int> deleteProduct(int productId)
        {
            try
            {
                return await objDAL.deleteProduct(productId);
            }
            catch (Exception ex)
            {
                objDAL.addErrorData(ex.Message, ex.StackTrace);
                return 0;
            }
        }

        public void addErrorData(string errorMessage, string stackTrace)
        {
            try
            {
                objDAL.addErrorData(errorMessage, stackTrace);
            }
            catch (Exception ex)
            {
                objDAL.addErrorData(ex.Message, ex.StackTrace);
            }
        }

    }
}