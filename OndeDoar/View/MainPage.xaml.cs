using OndeDoar.ViewModel;
using Xamarin.Forms;

namespace OndeDoar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation); 
        }
    }
}
