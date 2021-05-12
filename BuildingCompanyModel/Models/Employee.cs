using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class Employee : Person
    {
        [Range(0, 100000)]
        public decimal Salary { get; set; }

        [Required]
        public Position Position { get; set; }

        public override string ToString() => $"{Name}, {Surname}, {Salary}, {Position}";
    }
}
