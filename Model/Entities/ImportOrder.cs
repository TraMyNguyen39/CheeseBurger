using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class ImportOrder
    {
        [Key]
        public int ImportOrderID { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime DateIO { get; set; }

		[Required]
		public float TMoneyIO { get; set; }

        public int StaffID { get; set; }
        [ForeignKey("StaffID")]
        public virtual Staff Staff { get; set; }
        public int PartnerID { get; set; }
		[ForeignKey("PartnerID")]
        public virtual Partner Partner { get; set; }
	}
}
