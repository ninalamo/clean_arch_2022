using clean_arch.application.Commands.Customers.AddCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clean_arch_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("testinG");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCustomerCommand poco)
        {
            return Ok(await _mediator.Send(poco));
        }
    }

    public class TestPoco
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
