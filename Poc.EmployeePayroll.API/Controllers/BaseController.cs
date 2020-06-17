using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Poc.EmployeePayroll.API.Controllers
{
    public class BaseController : ControllerBase
    {
        internal IMediator Mediator { get; private set; }
        public BaseController(IMediator mediator) => Mediator = mediator;
    }
}
