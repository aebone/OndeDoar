using System;
using System.Collections.Generic;
using System.Diagnostics;
using OndeDoar.Model;
using Xamarin.Forms;

namespace OndeDoar.View
{
    public partial class ListDetailPage : ContentPage
    {
        string sel;

        public ListDetailPage(Place selected)
        {
            InitializeComponent();
            //sel = selected.Name;
            //Debug.WriteLine(sel);
            ItemName.Text = selected.Name;
        }
    }
}
