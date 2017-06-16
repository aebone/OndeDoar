using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace OndeDoar.Service
{
	public class AzureService<T>
	{
		IMobileServiceClient Client;
		IMobileServiceTable<T> Table;

		public AzureService()
		{
			string MyAppServiceURL = "http://ondedoar.azurewebsites.net";
			Client = new MobileServiceClient(MyAppServiceURL);
			Table = Client.GetTable<T>();
		}

		public Task<IEnumerable<T>> GetTable()
		{
			return Table.ToEnumerableAsync();
		}

	}
}
