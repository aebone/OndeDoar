using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OndeDoar.View
{
    public partial class PrivacyPage : ContentPage
    {
        public PrivacyPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
