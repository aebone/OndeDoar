using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OndeDoar.View
{
    public partial class MapsPage : ContentPage
    {
        // To transform latitude/longitude in street address
        Geocoder GeoCoder;

        public MapsPage()
        {
            InitializeComponent();

            GeoCoder = new Geocoder();

            GetMap();
        }

        private async void GetMap()
        {
            // Map
			var map = new Map(
			MapSpan.FromCenterAndRadius(
					new Position(-30.023067, -51.1743), Distance.FromMiles(5)))
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
			string address0 = "Porto Alegre";
            string address1 = "dom vital 248, Porto Alegre";
            string address2 = "Rua Gonçalves Dias, 170 - Porto Alegre";

            var address = new string[3];

            for (int i = 0; i <= 2; i++) {
                if (i == 0)
                    address[i] = address0;
                else if (i == 1)
                    address[i] = address1;
                else
                    address[i] = address2;
            }

            for (int i = 0; i <= 2; i++)
            {
                var approximateLocations = await GeoCoder.GetPositionsForAddressAsync(address[i]);

                foreach (var position in approximateLocations)
                {
                    Debug.WriteLine(position.Latitude + ", " + position.Longitude + "\n");

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = "custom pin",
                        Address = "custom detail info"
                    };
                    map.Pins.Add(pin);
                }
            }
		}
    }
}
