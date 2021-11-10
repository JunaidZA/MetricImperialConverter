using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MetricImperialConverter.Service.Interfaces;
using MetricImperialConverter.Common.Models;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace MetricImperialConverter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertController : ControllerBase
    {
        private readonly IConvertService _convertService;

        public ConvertController(IConvertService convertService)
        {
            _convertService = convertService;
        }

        /// <summary>
        /// Converts a temperature between Metric and Imperial.
        /// </summary>
        /// <param name="convertRequest"></param>
        /// <returns>The converted amount</returns>
        [HttpPost]
        [Consumes(Application.Json)]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<double>> ConvertAsync([FromBody] ConvertRequest convertRequest)
        {
            var convertedAmount = await _convertService.ConvertAsync(convertRequest.AmountToConvert, convertRequest.ConversionDirection, convertRequest.ConversionType);
            return Ok(convertedAmount);
        }
    }
}
