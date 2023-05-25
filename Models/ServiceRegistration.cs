namespace TrasladoSeguro.Models
{
    public class ServiceRegistration
    {
        public int Id { get; set; }
        public String Date { get; set; }

        public string ClienteIdentification { get; set; } = default!;
        public string? ClienteName { get; set; } = default!;
        public string DriverIdentification { get; set; } = default!;
        public string? DriverName { get; set; } = default!;
        public string ServiceType { get; set; } = default!;
    }

}
