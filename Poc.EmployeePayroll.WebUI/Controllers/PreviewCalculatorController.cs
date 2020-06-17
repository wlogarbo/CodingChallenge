using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.EmployeePayroll.Application.Features.CalculatorPreview;
using Poc.EmployeePayroll.Domain.Entities;
using Poc.EmployeePayroll.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.EmployeePayroll.WebUI.Controllers
{
    public class PreviewCalculatorController : BaseController
    {
        public PreviewCalculatorController(IMediator mediator) : base(mediator) { }

        public ActionResult Index()
        {
            var person = new Person()
            {
                PersonType = PersonType.Employee,
            };

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Person person)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDependent([Bind("Dependents")] Person person)
        {
            person.Dependents.Add(new Person() { PersonType = PersonType.Dependent });

            return PartialView("_DependentList", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDependent(Guid id, Person person)
        {
            var dep = person.Dependents.FirstOrDefault(x => x.Id == id);
            person.Dependents.Remove(dep);

            ModelState.Clear();

            return PartialView("_DependentList", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Calculate(Person person)
        {
            //TODO Need to send back ModelState errors to display
            if(ModelState.IsValid)
            {
                var response = await Mediator.Send(new PreviewCalculatorCalculate.Query()
                {
                    Person = person
                });

                return PartialView("_Calculation", response.Employee);
            }
            else
            {
                return View(person);
            }
        }
    }
}
