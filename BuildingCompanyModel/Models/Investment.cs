using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class Investment : BaseIdentifiable
    {
        [Range(0, 1000000)]
        public decimal Sum { get; set; }

        [Required]
        public Investor Investor { get; set; }

        public override string ToString() => $"Investor: {Investor.Name}, Sum: {Sum}";
    }
}
