using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
	public interface IPartnerService
	{
		List<Partner> GetListPartner(string name, string sortBy, bool isDescending);
		List<CBBPartnerDTO> GetListPartner();
		Partner GetPartner(int partnerID);
		void AddPartner(Partner p);
		void UpdatePartner(Partner p);
		void DeletePartner(int partnerID);
		void RecyclePartner(int partnerID);
		List<CBBPartnerDTO> GetPartnerNames();
		List<Ingredients> GetIngresbyPartner(int partnerID);
	}
}
