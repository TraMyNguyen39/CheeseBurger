using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
	public interface IPartnerService
	{
		List<Partner> GetListPartner(string name, string sortBy, bool isDescending, bool isDeleted);
		List<CBBPartnerDTO> GetListPartner();
		Partner GetPartner(int partnerID);
		void AddPartner(Partner p);
		void UpdatePartner(Partner p);
	}
}
