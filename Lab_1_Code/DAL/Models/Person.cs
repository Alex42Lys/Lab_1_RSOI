using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_1_Code.DAL.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; } = DateTimeOffset.Now.Second;
        [MaxLength(512)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string? Address { get; set; }
        [MaxLength(512)]
        public string? Work { get; set; }
        public int? Age { get; set; }



    }
}
