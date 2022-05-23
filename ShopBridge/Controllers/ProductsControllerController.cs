using ShopBridge.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class ProductsControllerController : ApiController
    {
        ProductBLL pBll = new ProductBLL();
        [HttpGet]
        [Route("Products/GetAllProducts")]
        public async Task<HttpResponseMessage> GetProduct()
        {
            try
            {
                List<Product> result = await pBll.getProducts();
                if (result.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No Data Available");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                pBll.addErrorData(ex.Message, ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

        [HttpGet]
        [Route("Products/GetProduct")]
        public async Task<HttpResponseMessage> GetProduct(int productId)
        {
            try
            {
                if (productId == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Pass Valid product ID");

                Product result = await pBll.getProduct(productId);
                if (result == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Data Available");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                pBll.addErrorData(ex.Message, ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

        [HttpPost]
        [Route("Products/AddProduct")]
        public async Task<HttpResponseMessage> PostProduct(Product product)
        {
            try
            {

                string validationMessage = "";

                if (product.productName == null) validationMessage += "Product Name cannot be null:";
                if (product.productDescription == null) validationMessage += "Product Description cannot be null:";
                if (product.productPrice == 0) validationMessage += "Product price cannot be null:";

                if (validationMessage != "")
                    return Request.CreateResponse(HttpStatusCode.BadRequest, validationMessage);

                var result = await pBll.addProduct(product);

                if (result == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Record not created");
                else
                    return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                pBll.addErrorData(ex.Message, ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

        [Route("Products/ModifyProduct")]
        public async Task<HttpResponseMessage> Put(Product product)
        {
            try
            {
                if (product.productId == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Pass Valid product ID");

                var result = await pBll.updateProduct(product);

                if (result == 0)
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Record not found");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                pBll.addErrorData(ex.Message, ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Products/DeleteProduct")]
        public async Task<HttpResponseMessage> DeleteProduct(int productId)
        {
            try
            {
                if (productId == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Pass Valid product ID");

                var result = await pBll.deleteProduct(productId);

                if (result == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Record not found");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                pBll.addErrorData(ex.Message, ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }

    }
}
