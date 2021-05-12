using System;
using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class Person : BaseIdentifiable
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
