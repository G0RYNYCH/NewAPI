using AutoMapper;
using Meetups.Aplication.Meetups.Commands.CreateMeetup;
using Meetups.Aplication.Meetups.Commands.DeleteCommand;
using Meetups.Aplication.Meetups.Commands.UpdateMeetup;
using Meetups.Aplication.Meetups.Queries.GetMeetupDetails;
using Meetups.Aplication.Meetups.Queries.GetMeetupList;
using Meetups.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.WebAPI.Controllers
{
    public class MeetupController : BaseController
    {
        private readonly IMapper _mapper;

        public MeetupController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<MeetupListViewModel>> GetAll() // returns action result with meetupListVM object
        {
            var query = new GetMeetupListQuery
            {
                UserId = UserId
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel); //Creates an Microsoft.AspNetCore.Mvc.OkObjectResult object that produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK response.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetupDetailsViewModel>> GetMeetup(Guid id)
        {
            var query = new GetMeetupDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMeetupDto createMeetupDto)
        {
            var command = _mapper.Map<CreateMeetupCommand>(createMeetupDto);
            command.UserId = UserId;
            var meetupId = await Mediator.Send(command);
            return Ok(meetupId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMeetupDto updateMeetupDto)
        {
            var command = _mapper.Map<UpdateMeetupCommand>(updateMeetupDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMeetupCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
