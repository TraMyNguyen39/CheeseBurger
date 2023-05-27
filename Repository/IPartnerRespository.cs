using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
	public interface IPartnerRespository
	{
		List<Partner> GetListPartner(string name, string sortBy, bool isDescending, bool isDeleted);
		List<Partner> GetListPartner();
		Partner GetPartner(int partnerID);
		void AddPartner(Partner p);
		void UpdatePartner(Partner p);
		List<CBBPartnerDTO> GetPartnerNames();
	}
}
