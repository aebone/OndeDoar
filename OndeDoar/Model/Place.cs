using System;
using Microsoft.WindowsAzure.MobileServices;

namespace OndeDoar.Model
{
	[DataTable("Places")]
	public class Place
	{
		[Version]
		public string AzureVersion { get; set; }

		public string Id { get; set; }
		public string Name { get; set; }
		public string What { get; set; }
		public string Image { get; set; }
		public string Category { get; set; }
		public string Address { get; set; }
		public bool Approved { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Site { get; set; }
	}
}
