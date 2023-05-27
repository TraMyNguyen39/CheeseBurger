using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.Model.Entities
{
    public class NewPass
    {
        [Key]
        public int NewPassID { get; set; }
        [Required]
        public string NewPassName { get; set; }
    }
}
