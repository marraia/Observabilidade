using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiaDemo.Application.AppSale.Input;
using AcademiaDemo.Application.Interfaces;
using Elastic.Apm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleAppService _saleAppService;
        public SaleController(
            ISaleAppService saleAppService
        )
        {
            _saleAppService = saleAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] SaleInput input)
        {
            var transaction = Agent.Tracer.StartTransaction("Criando uma venda!", "Requisição");
            try
            {
                await _saleAppService.InsertAsync(input);
                return Created("", "");
            }
            catch (Exception ex)
            {
                transaction.CaptureException(ex);
                return BadRequest($"Erro => {ex.Message}");
            }
            finally
            {
                transaction.End();
            }
        }
    }
}
