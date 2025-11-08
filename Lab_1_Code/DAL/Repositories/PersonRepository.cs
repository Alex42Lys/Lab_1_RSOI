using Lab_1_Code.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab_1_Code.DAL.Repositories
{
    public class PersonRepository(PersonDbContext _context) : IPersonRepository
    {
        public async Task<Person> GetPersonById(int id)
        {
            var ans = await _context.PersonBase.FindAsync(id);
            return ans;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            var ans = await _context.PersonBase.ToListAsync();
            return ans;
        }
        public async Task<int> AddPerson(Person person)
        {
            var ans = await _context.PersonBase.AddAsync(person);
            await _context.SaveChangesAsync();
            return ans.Entity.Id;
        }
        public async Task<int> UpdatePerson(Person person)
        {
            var ans = _context.Update(person);
            await _context.SaveChangesAsync();
            return ans.Entity.Id;
        }
        public async Task<int> DeletePerson(Person person)
        {
            var ans = _context.Remove(person);
            await _context.SaveChangesAsync();
            return ans.Entity.Id;
        }
    }
}
