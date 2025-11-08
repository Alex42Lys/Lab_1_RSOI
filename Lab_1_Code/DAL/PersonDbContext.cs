using Lab_1_Code.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab_1_Code.DAL
{
    public class PersonDbContext(DbContextOptions<PersonDbContext> options) : DbContext(options)
    {
        public DbSet<Person> PersonBase { get; set; }

    }
}
