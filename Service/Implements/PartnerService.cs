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

		public List<Partner> GetListPartner(string name, string sortBy, bool isDescending)
		{
			return partnerRespository.GetListPartner(name, sortBy, isDescending);
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

		public List<CBBPartnerDTO> GetPartnerNames()
		{
			return partnerRespository.GetPartnerNames();
		}

		public void RecyclePartner(int partnerID)
		{
			partnerRespository.RecyclePartner(partnerID);
		}

		public List<Ingredients> GetIngresbyPartner(int partnerID)
		{
			return partnerRespository.GetIngresbyPartner(partnerID);
		}

		public void DeletePartner(int partnerID)
		{
			// Xoa nha cung cap
			var partner = partnerRespository.GetPartner(partnerID);
			partner.isDeleted = true;
			partnerRespository.UpdatePartner(partner);
		}
	}
}
