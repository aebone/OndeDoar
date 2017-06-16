using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using OndeDoar.Model;
using Xamarin.Forms;

namespace OndeDoar.ViewModel
{
	public class NewPlaceViewModel : BaseViewModel
	{
		private string _nameText;
		private string _addressText;
		private string _whatText;
		private string _categoryText;
		private string _phoneText;
		private string _emailText;

		IMobileServiceTable<Place> todoTable;
		MobileServiceClient client;

		public string NameText
		{
			get { return _nameText; }
			set
			{
				if (SetProperty(ref _nameText, value))
					AddPlaceCommand.ChangeCanExecute();
			}
		}

		public string AddressText
		{
			get { return _addressText; }
			set
			{
				if (SetProperty(ref _addressText, value))
					AddPlaceCommand.ChangeCanExecute();
			}
		}

		public string WhatText
		{
			get { return _whatText; }
			set
			{
				if (SetProperty(ref _whatText, value))
					AddPlaceCommand.ChangeCanExecute();
			}
		}

		public string CategoryText
		{
			get { return _categoryText; }
			set
			{
				if (SetProperty(ref _categoryText, value))
					AddPlaceCommand.ChangeCanExecute();
			}
		}

		public string PhoneText
		{
			get { return _phoneText; }
			set
			{
				if (SetProperty(ref _phoneText, value))
					AddPlaceCommand.ChangeCanExecute();
			}
		}

		public string EmailText
		{
			get { return _emailText; }
			set
			{
				if (SetProperty(ref _emailText, value))
					AddPlaceCommand.ChangeCanExecute();
			}
		}
		public Command AddPlaceCommand { get; }

		public NewPlaceViewModel()
		{
			this.client = new MobileServiceClient(
				"http://ondedoar.azurewebsites.net");
			this.todoTable = client.GetTable<Place>();
			AddPlaceCommand = new Command(ExecuteAddPlaceCommand, CanExecuteAddPlaceCommand);
		}

		private bool CanExecuteAddPlaceCommand()
		{
			if (string.IsNullOrWhiteSpace(NameText))
			{
				return false;
			}
			else if (string.IsNullOrWhiteSpace(AddressText))
			{
				return false;
			}
			else if (string.IsNullOrWhiteSpace(CategoryText))
			{
				return false;
			}
			else
				return true;
		}

		private async void ExecuteAddPlaceCommand()
		{
			Debug.WriteLine($"biuguguy {DateTime.Now} { NameText }");
			await SaveTask(new Place { 
                Name = NameText, 
                Address = AddressText, 
                Category = CategoryText, 
                Email = EmailText, 
                What = WhatText, 
                Phone = PhoneText 
            });
		}

		public async Task SaveTask(Place item)
		{
			await todoTable.InsertAsync(item);
		}
	}
}