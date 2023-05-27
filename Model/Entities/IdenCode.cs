using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class IdenCode
    {
        [Key]
        public int IcodeId { get; set; }

        [Required]
        public string ICodeName { get; set; }
    }
}
