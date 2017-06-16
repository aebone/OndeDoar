using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using OndeDoar.Model;
using Xamarin.Forms;

namespace OndeDoar.ViewModel
{
    
		public class ListViewModel : INotifyPropertyChanged
		{
			private bool Busy;

			public event PropertyChangedEventHandler PropertyChanged;

			public ObservableCollection<Place> Places { get; set; }

			public Command GetPlacesCommand { get; set; }

			public ListViewModel()
			{
				Places = new ObservableCollection<Place>();
				GetPlacesCommand = new Command(
					async () => await GetPlaces(),
				   () => !IsBusy
				   );
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
					GetPlacesCommand.ChangeCanExecute();
				}
			}

			async Task GetPlaces()
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
				return;
			}
		}
    }

