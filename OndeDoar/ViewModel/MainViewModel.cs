using System;
using System.Diagnostics;
using System.Threading.Tasks;
using OndeDoar.View;
using Xamarin.Forms;

namespace OndeDoar.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
		public Command ShowMapCommand { get; set; }
        public Command ShowListCommand { get; set; }
        public Command NewPlaceCommand { get; set; }
        public Command ShowFaqCommand { get; set; }
        public Command ShowPrivacyCommand { get; set; }

		public MainViewModel(INavigation navigation)
		{
			Navigation = navigation;
			ShowMapCommand = new Command(async () => await ShowMap());
            ShowListCommand = new Command(async () => await ShowList());
            NewPlaceCommand = new Command(async () => await NewPlace());
            ShowFaqCommand = new Command(async () => await ShowFaq());
            ShowPrivacyCommand = new Command(async () => await ShowPrivacy());
		}

        private async Task ShowFaq()
        {
            await Navigation.PushModalAsync(new FaqPage());
        }

        private async Task NewPlace()
        {
            await Navigation.PushAsync(new NewPlacePage());
        }

        private async Task ShowList()
        {
            await Navigation.PushAsync(new ListPage());
        }

		private async Task ShowMap()
		{
			await Navigation.PushAsync(new MapsPage());
		}

		private async Task ShowPrivacy()
		{
            await Navigation.PushModalAsync(new PrivacyPage());
		}
    }
}
