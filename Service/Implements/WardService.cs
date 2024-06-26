﻿using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class WardService : IWardService
	{
		private readonly IWardRespository wardRespository;
		public WardService(IWardRespository wardRespository)
		{
			this.wardRespository = wardRespository;
		}
		public List<Ward> GetListWards()
		{
			return wardRespository.GetListWards();
		}
		public Ward GetWard(int id)
		{
			return wardRespository.GetWard(id);
		}
		public int GetWardIDByName(string name)
		{
			return wardRespository.GetWardIDByName(name);
		}
	}
}
