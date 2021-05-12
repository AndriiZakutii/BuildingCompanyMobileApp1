using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class Investor : IIdentifiable
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }
        public string PassportNo { get; set; }

        public override string ToString() => $"{Name}, {Surname}, {PassportNo}";
    }
}
