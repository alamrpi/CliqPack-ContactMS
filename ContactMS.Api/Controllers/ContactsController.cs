using ContactMS.Application.Contacts.Commands.Create;
using ContactMS.Application.Contacts.Commands.Update;
using ContactMS.Application.Contacts.Queries.GetById;
using ContactMS.Application.Contacts.Queries.Gets;
using ContactMS.Contracts.Contact;
using ContactMS.Contracts.QueryParams.Contact;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactMS.Api.Controllers
{
    [Route("contacts")]
    public class ContactsController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public ContactsController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        /// <summary>
        /// Get list of contact with pagination
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery]ContactQueryParam queryParam)
        {
            var result = await _sender.Send(new GetContactsQuery(queryParam));

            return result.Match(
                result => Ok(result),
                Problem);
        }

        /// <summary>
        /// Get single contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _sender.Send(new GetContactByIdQuery(id));

            return result.Match(
                result => Ok(result),
                Problem);
        }

        /// <summary>
        /// Create contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] CreateContactRequest request)
        {
            var command = _mapper.Map<CreateContactCommand>(request);

            var result = await _sender.Send(command);

            return result.Match(
                result => CreatedAtAction(nameof(Get), new {id = result.Id}, result), 
                Problem);
        }

        /// <summary>
        /// Update contact by the id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateContactRequest request)
        {
            var command = _mapper.Map<UpdateContactCommand>(request);

            var result = await _sender.Send(new UpdateContactCommand(id, request.Name, request.PhoneNumber, request.Email, request.Address));

            return result.Match(
                result => AcceptedAtAction(nameof(Get), new { id }, new {}),
                Problem);
        }

        /// <summary>
        /// Delete a contact by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteContactCommand(id);

            var result = await _sender.Send(command);

            return result.Match(
                result => NoContent(),
                Problem);
        }
    }
}
