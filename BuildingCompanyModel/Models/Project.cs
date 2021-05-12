using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class Project : BaseIdentifiable
    {
        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }
        public DateTime Start { get; set; }

        public ProjectType Type { get; set; }
        public ProjectStage Stage { get; set; }

        public IEnumerable<Investment> Investments { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public override string ToString() => $"{Name}, {Type}, {Stage}, {Cost}";
    }
}
