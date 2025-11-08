using Lab_1_Code.DAL.Models;

namespace Lab_1_Code.DAL.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> GetPersonById(int id);

        public Task<List<Person>> GetAllPersons();
        public Task<int> AddPerson(Person person);
        public Task<int> UpdatePerson(Person person);
        public Task<int> DeletePerson(Person person);
    }
}
