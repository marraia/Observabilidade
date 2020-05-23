using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiaDemo.Application.AppItem.Input;
using AcademiaDemo.Application.AppStock.Input;
using AcademiaDemo.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    { 
        private readonly IStockAppService _stockAppService;
        public StockController(
            IStockAppService stockAppService
        )
        { 
            _stockAppService = stockAppService;
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] Guid id)
        {
            var obj = await _stockAppService.UpdateAsync(id);

            if (obj == null)
                return NotFound();

            return Accepted("", obj);
        }
    }
}
