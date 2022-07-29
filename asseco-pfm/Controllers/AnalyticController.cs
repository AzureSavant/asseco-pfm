using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using asseco_pfm.Commands;
using asseco_pfm.Services;

namespace asseco_pfm.Controllers
{
    [ApiController]
    [Route("analytics")]
    public class AnalyticController : Controller
    {
        private readonly IAnalyticService _analyticsService;

        public AnalyticController(IAnalyticService analyticService)
        {
            _analyticsService = analyticService;    
        }
        [HttpGet]
        public IActionResult SpendingsGet([FromQuery] string catcode, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] DirectionsEnum direction)
        {
            var result = _analyticsService.SpendingsGet(catcode, startDate, endDate, direction);
            return Ok(result);
        }
    }
}
