using Braintree;
using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InvoiceManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayBillController : ControllerBase
    {
        private readonly IBraintreeService _braintreeService;

        public PayBillController(IBraintreeService braintreeService)
        {
            _braintreeService = braintreeService;
        }

        [HttpPost("createbraintoken")]
        public object PayBill()
        {
            var gateway=_braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            return clientToken;

        }
        [HttpPost("paybill")]
        public object PayBill(PaymentBillDto dto)
        {
            var request = new TransactionRequest
            {
                Amount = 10.00M,
                PaymentMethodNonce = "fake-valid*nonce",
                Options=new TransactionOptionsRequest
                {
                    SubmitForSettlement=true
                }

               
            };
            var gateway = _braintreeService.GetGateway();
            Result<Transaction> result = gateway.Transaction.Sale(request);
            return result;
        }

    }
}
