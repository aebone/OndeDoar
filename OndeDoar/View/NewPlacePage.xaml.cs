using System;
using System.Collections.Generic;
using OndeDoar.ViewModel;
using Xamarin.Forms;

namespace OndeDoar.View
{
    public partial class NewPlacePage : ContentPage
    {
        public NewPlacePage()
        {
            InitializeComponent();
            BindingContext = new NewPlaceViewModel();
        }
    }
}

