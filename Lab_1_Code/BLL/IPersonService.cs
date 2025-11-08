using Lab_1_Code.DTO.RequestDTOs;
using Lab_1_Code.DTO.ResponseDTOs;

namespace Lab_1_Code.BLL
{
    public interface IPersonService
    {
        public Task<List<PersonResposeDTO>> GetAll();
        public Task<PersonResposeDTO?> GetById(Guid id);
        public Task<Guid> Add(PersonRequestDTO personRequest);
        public Task<Guid?> Update(Guid id, PersonUpdateRequestDTO personRequest);
        public Task<Guid?> Delete(Guid id);

    }
}
