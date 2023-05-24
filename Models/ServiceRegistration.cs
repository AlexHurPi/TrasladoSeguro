namespace TrasladoSeguro.Models
{
    public class ServiceRegistration
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string? ClienteId { get; set; } = default!;
        public string? ClienteName { get; set; } = default!;
        public string? ClienteIdentification { get; set; } = default!;
        public string? DriverId { get; set; } = default!;
        public string? DriverName { get; set;} = default!;
        public string? DriverIdentification { get; set; } = default!;
        public string? ServiceTypeId { get; set; } = default!;
        public string? ServiceTypeName { get; set;} = default!;

    }
}
