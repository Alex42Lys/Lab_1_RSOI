using Lab_1_Code.BLL;
using Lab_1_Code.DAL.Models;
using Lab_1_Code.DTO.RequestDTOs;
using Lab_1_Code.DTO.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1_Code.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService) 
        {
            _personService = personService;
        }
        [HttpGet]
        [Route("/persons/{personId}")]
        [ProducesResponseType<IResult>(StatusCodes.Status200OK)]
        public async Task<IResult> GetPersonById(int personId)
        {
            var res = await _personService.GetById(personId);
            if(res == null || res.Name == null)
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

        [HttpGet]
        [Route("/persons")]
        [ProducesResponseType<IResult>(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllPersons()
        {
            var res = await _personService.GetAll();
            if (res == null || res.Count == 0)
            {
                return Results.NotFound();
            }
            return Results.Ok(res);
        }


        [HttpPatch]
        [Route("/persons/{personId}")]
        [ProducesResponseType<IResult>(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllPersons(int personId, PersonUpdateRequestDTO personUpdateRequestDTO )
        {
            var res = await _personService.Update(personId, personUpdateRequestDTO);
            if (res == null)
            {
                return Results.Problem();
            }
            return Results.Ok(res);
        }

        [HttpDelete]
        [Route("/persons/{personId}")]
        [ProducesResponseType<IResult>(StatusCodes.Status200OK)]
        public async Task<IResult> DeletePersob(int personId)
        {
            var ans = await _personService.Delete(personId);
            var res = await _personService.GetById(personId);

            if (res == null)
            {
                return Results.NoContent();
            }
            return Results.NotFound();
        }
    }
}
