using Api.Verbs.Dictionary.Aplication;
using Api.Verbs.Dictionary.Models;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Api.Verbs.Dictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VerbsController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<VerbDto>> GetVerb(Query.QueryVerb data)
        {
            return await _mediator.Send(data);
        } 
    }
}
