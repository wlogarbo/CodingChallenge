using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Poc.EmployeePayroll.WebUI.Controllers
{
    public class BaseController : Controller
    {
        internal IMediator Mediator { get; private set; }
        public BaseController(IMediator mediator) => Mediator = mediator;
    }
}
