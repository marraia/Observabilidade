using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiaDemo.Application.AppPayment.Input;
using AcademiaDemo.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentAppService _paymentAppService;
        public PaymentController(
            IPaymentAppService paymentAppService
        )
        {
            _paymentAppService = paymentAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] PaymentInput input)
        {
            try
            {
                var pay = await _paymentAppService.InsertAsync(input);
                return Created("", pay);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Payment => {ex.Message}");
            }
        }
    }
}
