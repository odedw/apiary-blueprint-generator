using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartExample.Controllers
{
    /// <summary> The following is a section of resources related to the shopping cart </summary>
    /// <title>Shopping Cart Resources</title>
    public class ShoppingCartController : ApiController
    {
        /// <summary> List products added into your shopping-cart </summary>
        /// <resource method="GET">/shopping-cart</resource>
        /// <headers>
        ///     <response name="Content-Type">application/json</response>
        /// </headers>
        /// <example>
        ///     <code type="output"> { "items": [{ "url": "/shopping-cart/1", "product":"2ZY48XPZ", "quantity": 1, "name": "New socks", "price": 1.25 }] } </code>
        /// </example>        
        public Dictionary<string, object> Get()
        {
            return new Dictionary<string, object>
                       {
                           {"items", new[]
                                         {
                                             new Dictionary<string,object>
                                                 {
                                                     {"url","/shopping-cart/1"},
                                                     {"product","2ZY48XPZ"},
                                                     {"quantity", 1},
                                                     {"name", "New socks"},
                                                     {"price", 1.25}
                                                 }
                                         }}
                       };
        }

        /// <summary> Save new products in your shopping cart </summary>
        /// <resource method="POST">/shopping-cart</resource>
        /// <headers>
        ///     <request name="Content-Type">application/json</request>
        ///     <response name="Content-Type">application/json</response>
        /// </headers>
        /// <example> 
        ///     <code type="input"> { "product":"1AB23ORM", "quantity": 2 } </code>  
        ///     <code type="output"> { "status": "created", "url": "/shopping-cart/2" } </code>
        /// </example>        
        /// <returns status-code="201"></returns>
        public HttpResponseMessage Post(Dictionary<string, object> newItem)
        {
            var dict = new Dictionary<string, string>
                       {
                           {"status","created"},
                           {"url","/shopping-cart/2"}
                       };
            return Request.CreateResponse(HttpStatusCode.Created, dict);
        }
    }
}