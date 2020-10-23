using System.ComponentModel.DataAnnotations;
/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    public class Driver
    {
        [Key]
        public string DriverNumber { get; set; }
    }
}
