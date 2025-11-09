namespace Lab_1_Code.DTO.RequestDTOs
{
    public record class PersonUpdateRequestDTO
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? Work { get; set; }
    }
}
