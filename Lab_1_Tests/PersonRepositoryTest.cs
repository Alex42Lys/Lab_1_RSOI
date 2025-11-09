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
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
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
        public async Task TestIsFinding()
        {
            var entityId1 = await _personRepository.AddPerson(new Person()
            {
                Name = "John Doe",
                Age = 20
            });
            var entityId2 = await _personRepository.AddPerson(new Person()
            {
                Name = "Jane Doe",
                Age = 20
            });
            var entity1 = await _personRepository.GetPersonById(entityId1);
            var entity2 = await _personRepository.GetPersonById(entityId2);
            var id1 = entity1.Id;
            var id2 = entity2.Id;
            Assert.NotNull(entity1);
            Assert.NotNull(entity2);
            Assert.NotEqual(id1, id2);


        }
        [Fact]
        public async Task TestIsDeleting()
        {
            var entityId = await _personRepository.AddPerson(new Person()
            {
                Name = "John Doe for Delete",
            });
            var entity = await _context.PersonBase.FirstOrDefaultAsync(p => entityId == p.Id);
            await _personRepository.DeletePerson(entity);

            Assert.Null(_context.PersonBase.FirstOrDefault(p => p.Id == entityId));
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
            entity.Occupation = "BMSTU";
            await _personRepository.UpdatePerson(entity);

            Assert.NotEqual("John Doe for Update", entity.Name);
            Assert.Equal("BMSTU", entity.Occupation);
        }

    }
}