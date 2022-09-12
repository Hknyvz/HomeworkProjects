using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createProgrammingLanguageCommand)
        {
            return Created("", await Mediator.Send(createProgrammingLanguageCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateProgrammingLanguageCommand)
        {
            return Ok(await Mediator.Send(updateProgrammingLanguageCommand));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteProgrammingLanguageCommand)
        {
            return Ok(await Mediator.Send(deleteProgrammingLanguageCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetTechnologyQueryById getByIdIdProgrammingLanguageQuery)
        //{
        //    GetTechnologyByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdIdProgrammingLanguageQuery);
        //    return Ok(programmingLanguageGetByIdDto);
        //}
    }
}
