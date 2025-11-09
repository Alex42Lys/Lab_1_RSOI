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
                .Select(x => new PersonResposeDTO(x.Id, x.Name, x.Age ?? 0, x.Address ?? "", x.Work ?? ""))
                .ToList();
        }

        public async Task<PersonResposeDTO?> GetById(int id)
        {
            var entity = await _personRepository.GetPersonById(id);
            return entity == null ?
                null :
                new PersonResposeDTO(entity.Id, entity.Name, entity.Age ?? 0, entity.Address ?? "", entity.Work ?? "");
        }

        public async Task<int> Add(PersonRequestDTO personRequest)
        {
            return await _personRepository.AddPerson(new Person()
            {
                Name = personRequest.Name,
                Age = personRequest.Age,
                Address = personRequest.Address,
                Work = personRequest.Work
            });
        }

        public async Task<Person> Update(int id, PersonUpdateRequestDTO personRequest)
        {
            var entity = await _personRepository.GetPersonById(id);
            if (entity == null) return null;
            entity.Name = personRequest.Name ?? entity.Name;
            entity.Age = personRequest.Age ?? entity.Age;
            entity.Address = personRequest.Address ?? entity.Address;
            entity.Work = personRequest.Work ?? entity.Work;

            await _personRepository.UpdatePerson(entity);
            return entity;
        }

        public async Task<int?> Delete(int id)
        {
            var entity = await _personRepository.GetPersonById(id);
            if (entity == null) return null;
            await _personRepository.DeletePerson(entity);
            return id;
        }
    }
}
