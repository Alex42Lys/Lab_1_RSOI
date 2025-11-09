using Lab_1_Code.DAL.Models;
using Lab_1_Code.DTO.RequestDTOs;
using Lab_1_Code.DTO.ResponseDTOs;

namespace Lab_1_Code.BLL
{
    public interface IPersonService
    {
        public Task<List<PersonResposeDTO>> GetAll();
        public Task<PersonResposeDTO?> GetById(int id);
        public Task<int> Add(PersonRequestDTO personRequest);
        public Task<Person> Update(int id, PersonUpdateRequestDTO personRequest);
        public Task<int?> Delete(int id);

    }
}
