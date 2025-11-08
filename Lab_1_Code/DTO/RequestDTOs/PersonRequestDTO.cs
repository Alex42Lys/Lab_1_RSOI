namespace Lab_1_Code.DTO.RequestDTOs
{
    public record class PersonRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Surname {  get; set; }
        public string? Occupation {  get; set; }
    }
}
