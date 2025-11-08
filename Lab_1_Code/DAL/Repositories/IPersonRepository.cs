using Lab_1_Code.DAL.Models;

namespace Lab_1_Code.DAL.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> GetPersonById(Guid id);

        public Task<List<Person>> GetAllPersons();
        public Task<Guid> AddPerson(Person person);
        public Task<Guid> UpdatePerson(Person person);
        public Task<Guid> DeletePerson(Person person);
    }
}
