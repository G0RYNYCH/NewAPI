using AutoMapper;
using MediatR;
using Meetups.Aplication.Meetups.Commands.CreateMeetup;
using Meetups.Aplication.Meetups.Commands.DeleteCommand;
using Meetups.Aplication.Meetups.Commands.UpdateMeetup;
using Meetups.Aplication.Meetups.Queries.GetMeetupDetails;
using Meetups.Aplication.Meetups.Queries.GetMeetupList;
using Meetups.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Meetups.WebAPI.Controllers
{
    public class MeetupsController : BaseController
    {
        private readonly IMapper _mapper;

        public MeetupsController(IMapper mapper, IMediator mediator) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<MeetupListViewModel>> GetAll() // returns action result with meetupListVM object
        {
            var query = new GetMeetupListQuery();
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel); //Creates an Microsoft.AspNetCore.Mvc.OkObjectResult object that produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK response.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetupDetailsViewModel>> GetMeetup(Guid id)
        {
            var query = new GetMeetupDetailsQuery
            {
                Id = id
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMeetupDto createMeetupDto)
        {
            var command = _mapper.Map<CreateMeetupCommand>(createMeetupDto);
            var meetupId = await Mediator.Send(command);
            return Ok(meetupId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMeetupDto updateMeetupDto)
        {
            var command = _mapper.Map<UpdateMeetupCommand>(updateMeetupDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMeetupCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
