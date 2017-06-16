using System;
using System.Collections.Generic;
using OndeDoar.ViewModel;
using Xamarin.Forms;

namespace OndeDoar.View
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListViewModel(); 
        }
    }
}
