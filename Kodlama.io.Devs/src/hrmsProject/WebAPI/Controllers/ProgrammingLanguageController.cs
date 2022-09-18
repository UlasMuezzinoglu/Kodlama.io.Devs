using Application.Features.programmingLanguage.addProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Models;
using Application.Features.programmingLanguage.Queries.GetListOfProgrammingLanguage;
using Application.Features.programmingLanguage.Queries.GetProgrammingLanguageById;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProgrammingLanguageByIdQuery getProgrammingLanguageByIdQuery)
        {
            GetProgrammingLanguageByIdDto result = await Mediator.Send(getProgrammingLanguageByIdQuery);
            return Created("", result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }


    }
}
