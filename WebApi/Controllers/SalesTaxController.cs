using Microsoft.AspNetCore.Mvc;
using SalesTaxCalculator.BusinessEntities.Models;
using SalesTaxCalculator.BusinessLogic.Interfaces;

namespace SalesTaxCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesTaxController : ControllerBase
    {
        private readonly ISalesTaxCalculator _calculator;

        public SalesTaxController(ISalesTaxCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost("calculate")]
        [ProducesResponseType(typeof(ReceiptDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ReceiptDetails> CalculateTax([FromBody] Item[] items)
        {
            if (items == null || items.Length == 0)
            {
                return BadRequest("Items list cannot be empty");
            }

            var result = _calculator.Process(items);
            return Ok(result);
        }
    }
}