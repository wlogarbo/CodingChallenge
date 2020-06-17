using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.EmployeePayroll.Application.Features.CalculatorPreview;
using System.Threading.Tasks;

namespace Poc.EmployeePayroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewCalculatorController : BaseController
    {
        public PreviewCalculatorController(IMediator mediator) : base(mediator){}

        [HttpPost("Calculate")]
        public async Task<ActionResult<PreviewCalculatorCalculate.Response>> Calculate(PreviewCalculatorCalculate.Query query)
        {
            return await Mediator.Send(query);
        }
    }
}
