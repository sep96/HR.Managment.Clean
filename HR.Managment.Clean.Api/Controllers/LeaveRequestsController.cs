using HR.Managment.Application.Features.LeaveRequest.Queries;
using HR.Managment.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HR.Managment.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
using HR.Managment.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using HR.Managment.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using HR.Managment.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Managment.Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<List<LeaveRequestListDto>> Get()
        {
            return  await _mediator.Send(new GetLeaveRequestListQuery());
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDetailsDto> Get(int id)
        {
            return await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<int> Post([FromBody] CreateLeaveTypeCommand value)
        {
            return await _mediator.Send(value);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveTypeCommand value)
        {
            await _mediator.Send(value);
            return Ok();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand
            {
                LeaveTypeID = id
            });
            return Ok();
        }
    }
}
