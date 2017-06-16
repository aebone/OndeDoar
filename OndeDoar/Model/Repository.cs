using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OndeDoar.Model
{
	public class Repository
	{
		public async Task<List<Place>> GetPlaces()
		{
			var Service = new Service.AzureService<Place>();
			var Items = await Service.GetTable();
			return Items.ToList();
		}
	}
}
