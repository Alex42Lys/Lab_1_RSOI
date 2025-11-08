using Lab_1_Code.DAL.Models;
using Lab_1_Code.DAL.Repositories;
using Lab_1_Code.DTO.RequestDTOs;
using Lab_1_Code.DTO.ResponseDTOs;

namespace Lab_1_Code.BLL
{
    public class PersonService(IPersonRepository _personRepository) : IPersonService
    {
        public async Task<List<PersonResposeDTO>> GetAll()
        {
            return (await _personRepository.GetAllPersons())
                .Select(x => new PersonResposeDTO(x.Id, x.Name, x.Age ?? 0, x.Surname ?? "", x.Occupation ?? ""))
                .ToList();
        }

        public async Task<PersonResposeDTO?> GetById(Guid id)
        {
            var entity = await _personRepository.GetPersonById(id);
            return entity == null ?
                null :
                new PersonResposeDTO(entity.Id, entity.Name, entity.Age ?? 0, entity.Surname ?? "", entity.Occupation ?? "");
        }

        public async Task<Guid> Add(PersonRequestDTO personRequest)
        {
            return await _personRepository.AddPerson(new Person()
            {
                Name = personRequest.Name,
                Age = personRequest.Age,
                Surname = personRequest.Surname,
                Occupation = personRequest.Occupation
            });
        }

        public async Task<Guid?> Update(Guid id, PersonUpdateRequestDTO personRequest)
        {
            var entity = await _personRepository.GetPersonById(id);
            if (entity == null) return null;
            entity.Name = personRequest.Name ?? entity.Name;
            entity.Age = personRequest.Age ?? entity.Age;
            entity.Surname = personRequest.Surname ?? entity.Surname;
            entity.Occupation = personRequest.Occupation ?? entity.Occupation;

            await _personRepository.UpdatePerson(entity);
            return entity.Id;
        }

        public async Task<Guid?> Delete(Guid id)
        {
            var entity = await _personRepository.GetPersonById(id);
            if (entity == null) return null;
            await _personRepository.DeletePerson(entity);
            return id;
        }
    }
}
