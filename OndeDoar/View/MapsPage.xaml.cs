using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using OndeDoar.Model;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OndeDoar.View
{
    public partial class MapsPage : ContentPage
    {
        // To transform latitude/longitude in street address
        Geocoder GeoCoder;

		//public ObservableCollection<Place> Places { get; set; }
        private List<string> Places;
        private List<string> Names;

		public MapsPage()
        {
            InitializeComponent();
            GeoCoder = new Geocoder();

           

            Places = new List<string>();
            Names = new List<string>();

			GetMap();
        }


        private async void GetMap()
        {
			var Repository = new Repository();
			var Items = await Repository.GetPlaces();



			//Debug.WriteLine(Names);
			// Geolacator
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var myPosition = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            // Map
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(myPosition.Latitude, myPosition.Longitude), Distance.FromMiles(5)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			Content = stack;

			// Pins
			//string address0 = "Porto Alegre";
			//string address1 = "dom vital 248, Porto Alegre";
			//string address2 = "Rua Gonçalves Dias, 170 - Porto Alegre";

			//var address = new string[3];

			//for (int i = 0; i <= 2; i++) {
			//    if (i == 0)
			//        address[i] = address0;
			//    else if (i == 1)
			//        address[i] = address1;
			//    else
			//        address[i] = address2;
			//}

			//for (int i = 0; i <= Places.Count; i++)
			//{
			//var approximateLocations = await GeoCoder.GetPositionsForAddressAsync(address[i]);
			foreach (var Place in Items)
            {
		var approximateLocations = await GeoCoder.GetPositionsForAddressAsync(Place.Address);
                foreach (var position in approximateLocations)
                {
                    Debug.WriteLine(position.Latitude + ", " + position.Longitude + "\n");

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = Place.Name,
                        Address = Place.What
                    };
                    map.Pins.Add(pin);
                }
            }
		}
    }
}
