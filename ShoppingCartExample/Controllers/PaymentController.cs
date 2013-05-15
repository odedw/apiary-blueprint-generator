using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartExample.Controllers
{
    /// <title> Payment Resources </title>
    public class PaymentController : ApiController
    {
        /// <summary> This resource allows you to submit payment information to process your *shopping cart* items </summary>
        /// <resource method="POST" content-type="application/json">/payment</resource>
        /// <example>
        ///     <code type="input">
        ///        { "cc": "12345678900", "cvc": "123", "expiry": "0112" }
        ///     </code>  
        ///     <code type="output">
        ///         { "receipt": "/payment/receipt/1" }
        ///     </code>
        /// </example>        
        public Dictionary<string, string> Post()
        {
            return new Dictionary<string, string>
                       {
                           {"receipt","/payment/receipt/1"}
                       };
        }
    }
}
