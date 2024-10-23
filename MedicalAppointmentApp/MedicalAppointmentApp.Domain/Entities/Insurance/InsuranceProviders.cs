using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.Insurance
{
    [Table("InsuranceProviders", Schema = "insurance")]
    public class InsuranceProviders : Base.BaseEntity
    {
        [Key]
        public int InsuranceProviderID { get; set; }
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }        //El "?" significa que UpdateAt puede ser null
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? CoverageDetails { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsPreferred { get; set; }
        public int NetworkTypeId { get; set; }
        public string? CustomerSupportContact { get; set; }
        public string? AcceptedRegions { get; set; }
        public decimal? MaxCoverageAmount { get; set; }

        // actualizar proveedor de seguros en perfil del paciente
        public void UpdateInsuranceProvider(string name, string contactNumber, string email)
        {
            Name = name;
            ContactNumber = contactNumber;
            Email = email;
        }


    }
}
