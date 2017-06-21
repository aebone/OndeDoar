using System;
using System.Collections.Generic;
using System.Diagnostics;
using OndeDoar.Model;
using OndeDoar.ViewModel;
using Xamarin.Forms;

namespace OndeDoar.View
{
    public partial class ListDetailPage : ContentPage
    {

        public ListDetailPage(Place selected)
        {
            InitializeComponent();
            BindingContext = new ListDetailViewModel(selected);
        }
    }
}
