using System;

using Lab_1_Code.DAL;
using Lab_1_Code.DAL.Models;
using Lab_1_Code.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Lab_1_Tests
{
    public class PersonRepositoryTest
    {
        readonly PersonDbContext _context;
        PersonRepository _personRepository;
        public PersonRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<PersonDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            _context = new PersonDbContext(options);
            _personRepository = new PersonRepository(_context);
        }

        [Fact]
        public async Task TestIsCreating()
        {
            var entityId = await _personRepository.AddPerson(new Person()
            {
                Name = "John Doe",
                Age = 20
            });
            var entity = await _context.PersonBase.FirstOrDefaultAsync(p => entityId == p.Id);
            Assert.NotNull(entity);
        }

        [Fact]
        public async Task TestIsDeleting()
        {
            var entityId = await _personRepository.AddPerson(new Person()
            {
                Name = "John Doe for Delete",
            });
            var entity = await _context.PersonBase.FirstOrDefaultAsync(p => entityId == p.Id);
            var id = await _personRepository.DeletePerson(entity);
            Assert.Equal(entityId, id);
            
        }

        [Fact]
        public async Task TestIsUpdating()
        {
            var entityId = await _personRepository.AddPerson(new Person()
            {
                Name = "John Doe for Update",
                Age = 20
            });
            var entity = await _personRepository.GetPersonById(entityId);

            entity.Name = "John Doe Updated";
            entity.Work = "BMSTU";
            await _personRepository.UpdatePerson(entity);

            Assert.NotEqual("John Doe for Update", entity.Name);
            Assert.Equal("BMSTU", entity.Work);
        }
        [Fact]
        public async Task TestGetDeleted()
        {
            var entityId = await _personRepository.AddPerson(new Person()
            {
                Name = "John Doe",
                Age = 20
            });
            var entity = await _context.PersonBase.FirstOrDefaultAsync(p => entityId == p.Id);
            await _personRepository.DeletePerson(entity);
            Assert.Null(_context.PersonBase.FirstOrDefault(p => p.Id == entityId)); ;
        }
    }


}