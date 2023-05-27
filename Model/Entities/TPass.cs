using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.Model.Entities
{
    public class TPass
    {
        [Key]
        public int TPassID { get; set; }
        [Required]
        public string TPassName { get; set; }
    }
}
