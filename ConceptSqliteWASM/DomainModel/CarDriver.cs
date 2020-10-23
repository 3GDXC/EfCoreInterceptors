using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    public class CarDriver
    {
        [Key]
        public Guid ID { get; set; }

        public string RegistrationPlate { get; set; }
        public string DriverNumber { get; set; }
    }
}
