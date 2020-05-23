using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiaDemo.Application.AppItem.Input;
using AcademiaDemo.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemAppService _itemAppService;
        public ItemController(
            IItemAppService itemAppService
        )
        {
            _itemAppService = itemAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] ItemInput input)
        {
            try
            {
                await _itemAppService.InsertAsync(input);
                return Created("", "");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro => {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _itemAppService.GetAllAsync());
        }
    }
}
