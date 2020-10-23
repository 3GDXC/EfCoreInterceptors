using System.ComponentModel.DataAnnotations;
/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    public class Car
    {
        [Key]
        public string RegistrationPlate { get; set; }
    }
}
