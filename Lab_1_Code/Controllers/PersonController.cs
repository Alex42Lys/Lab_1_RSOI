using Lab_1_Code.BLL;
using Lab_1_Code.DAL.Models;
using Lab_1_Code.DTO.RequestDTOs;
using Lab_1_Code.DTO.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1_Code.Controllers
{
    [ApiController]
    [Route("api/personController")]
    public class PersonController : ControllerBase
    {
        IPersonService _personService;
        public PersonController(IPersonService personService) 
        {
            _personService = personService;
        }
        [HttpGet]
        [Route("/persons/{personId}")]
        [ProducesResponseType<IResult>(StatusCodes.Status200OK)]
        public async Task<IResult> GetPersonById(Guid personId)
        {
            var res = await _personService.GetById(personId);
            if(res == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(res);
        }
        [HttpPost]
        [Route("/persons")]
        [ProducesResponseType<IResult>(StatusCodes.Status200OK)]
        public async Task<IResult> AddPerson(PersonRequestDTO personRequestDTO)
        {
            var res = await _personService.Add(personRequestDTO);
            return Results.Created($"/persons/{res}", res);
        }
    }
}
