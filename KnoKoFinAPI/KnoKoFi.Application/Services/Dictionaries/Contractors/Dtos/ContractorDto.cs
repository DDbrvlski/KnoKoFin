namespace KnoKoFin.Application.Services.Dictionaries.Contractors.Dto
{
    public class ContractorDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; } //FirstName + LastName
        public string? ContractorType { get; set; }
    }
}
