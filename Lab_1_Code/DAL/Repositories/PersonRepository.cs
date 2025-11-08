using Lab_1_Code.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab_1_Code.DAL.Repositories
{
    public class PersonRepository(PersonDbContext _context) : IPersonRepository
    {
        public async Task<Person> GetPersonById(Guid id)
        {
            var ans = await _context.Persons.FindAsync(id);
            return ans;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            var ans = await _context.Persons.ToListAsync();
            return ans;
        }
        public async Task<Guid> AddPerson(Person person)
        {
            var ans = await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return ans.Entity.Id;
        }
        public async Task<Guid> UpdatePerson(Person person)
        {
            var ans = _context.Update(person);
            await _context.SaveChangesAsync();
            return ans.Entity.Id;
        }
        public async Task<Guid> DeletePerson(Person person)
        {
            var ans = _context.Remove(person);
            await _context.SaveChangesAsync();
            return ans.Entity.Id;
        }
    }
}
