using System.ComponentModel.DataAnnotations;

namespace Lab_1_Code.DAL.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string? Surname { get; set; }
        [MaxLength(512)]
        public string? Occupation { get; set; }
        public int? Age { get; set; }



    }
}
