using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class PartnerService : IPartnerService
	{
		private readonly IPartnerRespository partnerRespository;
		public PartnerService(IPartnerRespository partnerRespository)
		{
			this.partnerRespository = partnerRespository;
		}

		public Partner GetPartner(int partnerID)
		{
			return partnerRespository.GetPartner(partnerID);
		}

		public void AddPartner(Partner p)
		{
			partnerRespository.AddPartner(p);
		}

		public List<Partner> GetListPartner(string name, string sortBy, bool isDescending, bool isDeleted)
		{
			return partnerRespository.GetListPartner(name, sortBy, isDescending, isDeleted);
		}

		public void UpdatePartner(Partner p)
		{
			partnerRespository.UpdatePartner(p);
		}

		public List<CBBPartnerDTO> GetListPartner()
		{
			List<CBBPartnerDTO> partners = new List<CBBPartnerDTO>();
			var list = partnerRespository.GetListPartner();
			foreach (var item in list)
			{
				partners.Add(new CBBPartnerDTO { PartnerName = item.PartnerName, PartnerID = item.PartnerID });
			}
			return partners;
		}
	}
}
