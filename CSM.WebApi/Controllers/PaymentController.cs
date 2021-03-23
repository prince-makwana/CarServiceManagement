using CSM.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCRS.WebApi.Controllers
{
    public class PaymentsController : ApiController
    {
        [HttpGet]
        [Route("api/Payment/createPayment")]
        public HttpResponseMessage Index()
        {
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_IY4gqVRUhefixp", "eHJxZOC70eGNg1kmED2BXV52");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", 500 * 100); // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic , 0 - manual
                                                 //options.Add("notes", "-- You can put any notes here --");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();
            // Create order model for return on view
            OrderModel orderModel = new OrderModel
            {
                orderId = orderId,
                razorpayKey = "rzp_test_IY4gqVRUhefixp",
                amount = 500 * 100,
                currency = "INR",
                name = "Lalit Radadiya",
                email = "radadiya7lalit7@gmail.com",
                contactNumber = "7698281497",
                address = "a",
                description = "Testing description",
                tid = transactionId
            };
            return Request.CreateResponse(HttpStatusCode.OK, orderModel);


        }


        [HttpPost]
        [Route("api/Payment/checkPaymentStatus")]
        public HttpResponseMessage checkPaymentStatus([FromBody] PaymentViewModel model)
        {
            // Payment data comes in url so we have to get it from url
            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            string paymentId = model.rzp_paymentid;
            // This is orderId
            string orderId = model.rzp_orderid;
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_IY4gqVRUhefixp", "eHJxZOC70eGNg1kmED2BXV52");
            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);
            // This code is for capture the payment
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];
            //// Check payment made successfully
            if (paymentCaptured.Attributes["status"] == "captured")
            {
                // Create these action method
                return Request.CreateResponse(HttpStatusCode.OK, "Payment Success");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Payment Failed");
            }
        }


        //public InvoiceViewModel getBookingDetails(String bookingExID)
        //{

        //}
    }


}