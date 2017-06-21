using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using OndeDoar.Model;
using OndeDoar.View;
using Xamarin.Forms;

namespace OndeDoar.ViewModel
{
    
	public class ListViewModel : INotifyPropertyChanged
	{

		private bool Busy;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<Place> Places { get; set; }

		private Place _selectedItem { get; set; }

		public Place SelectedItem
		{

			get
			{
				return _selectedItem;
			}



			set
			{
				if (_selectedItem != value)
				{
					_selectedItem = value;
					OnPropertyChanged("SelectedItem");

					//this can be placed before or after propertychanged notification raised, 
					//depending on the situation
					//DoSomeDataOperation();
                    Debug.WriteLine(_selectedItem.Name);
                    Application.Current.MainPage.Navigation.PushAsync(new ListDetailPage(_selectedItem));
				}
			}

			//set{
			//	_selectedItem = value;
   //             OnPropertyChanged("SelectedItem");
			//	Application.Current.MainPage.Navigation.PushAsync(new ListDetailPage(_selectedItem));
			//	//Debug.WriteLine(_selectedItem.Name);
			//}
		}

		public ListViewModel()
		{
			Places = new ObservableCollection<Place>();
            GetPlaces();
		}

        private async void GetPlaces()
        {
			if (!IsBusy)
			{
				Exception Error = null;
				try
				{
					IsBusy = true;
					var Repository = new Repository();
					var Items = await Repository.GetPlaces();

					Places.Clear();
					foreach (var Place in Items)
					{
						Places.Add(Place);
					}
				}
				catch (Exception ex)
				{
					Error = ex;
				}
				finally
				{
					IsBusy = false;
				}





				if (Error != null)
				{
					await Application.Current.MainPage.DisplayAlert(
						"Error!", Error.Message, "OK");
				}





			}
        }
		
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			public bool IsBusy
			{
				get
				{
					return Busy;
				}
				set
				{
					Busy = value;
					OnPropertyChanged();
				}
			}

		
		}
    }

