using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class PartnerRespository : IPartnerRespository
	{
		private readonly CheeseBurgerContext context;
		public PartnerRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public void AddPartner(Partner p)
		{
			context.Partners.Add(p);
			context.SaveChanges();
		}

		public List<Partner> GetListPartner(string name, string sortBy, bool isDescending, bool isDeleted)
		{
			var partners = new List<Partner>();
			if (name != null)
			{
				partners =  context.Partners.Where(p=> p.PartnerName.Contains(name)).ToList();
			}
			else
			{
				partners = context.Partners.ToList();
			}
			if (sortBy != null)
			{
				if (isDescending == true)
					partners = partners.OrderByDescending(p => p.PartnerName).ToList();
				else
					partners = partners.OrderBy(p => p.PartnerName).ToList();
			}
			return partners.Where(p => p.isDeleted == isDeleted).ToList();
		}

		public List<Partner> GetListPartner()
		{
			return context.Partners.Where(p => p.isDeleted == false).ToList();
		}

		public Partner GetPartner(int partnerID)
		{
			return context.Partners.Find(partnerID);
		}

		public List<CBBPartnerDTO> GetPartnerNames()
		{
			return context.Partners.Select(p => new CBBPartnerDTO { PartnerID = p.PartnerID, PartnerName = p.PartnerName}).ToList();
		}

		public void UpdatePartner(Partner p)
		{
			context.Partners.Update(p);
			context.SaveChanges();
		}
	}
}
