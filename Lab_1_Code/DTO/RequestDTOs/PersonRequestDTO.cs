namespace Lab_1_Code.DTO.RequestDTOs
{
    public record class PersonRequestDTO
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Address {  get; set; }
        public string? Work {  get; set; }
    }
}
