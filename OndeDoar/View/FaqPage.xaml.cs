using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OndeDoar.View
{
    public partial class FaqPage : ContentPage
    {

        public FaqPage()
        {
            InitializeComponent();
        }

        private void BtnCloseClicked(object sender, EventArgs args) {
            this.Navigation.PopModalAsync();
        }
    }
}
