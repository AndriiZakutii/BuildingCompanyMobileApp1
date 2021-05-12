using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class Position : BaseIdentifiable
    {
        [Required]
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}