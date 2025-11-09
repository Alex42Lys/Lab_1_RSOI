namespace Lab_1_Code.DTO.ResponseDTOs
{
    public record class PersonResposeDTO
    {
        public PersonResposeDTO(int id, string name, int age, string surname, string occupation) 
        {
            Id = id;
            Name = name;
            Age = age;
            Address = surname;
            Work = occupation;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? Work { get; set; }
    }
}
