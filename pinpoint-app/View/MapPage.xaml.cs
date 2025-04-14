using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using pinpoint_app.Services;

namespace pinpoint_app.View;

public partial class MapPage : ContentPage
{
    DateTimeConversionService dateTimeConversionService = new DateTimeConversionService(); // service for converting date and time formats
    private readonly MapViewModel viewModel;

	public MapPage(MapViewModel mapViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel = mapViewModel; 
    }

	protected override async void OnAppearing()
    {// loads the map with the closest events when the page appears
        base.OnAppearing();
		await LoadMap(); 
    }
	public async Task LoadMap()
	{
		await viewModel.GetClosestEvents(); //fetches and fills the ClosestEvents observable collection
		ClosestEvents.Pins.Clear(); //clears out any old pins from the map

		foreach (var ev in viewModel.ClosestEvents)
		{
			var pin = new Pin
			{
				Label = ev.title,
				MarkerId = ev.id,
				Address = ev.address,
				Location = new Location(ev.lat, ev.lon),
				Type = PinType.Place
			};

			pin.MarkerClicked += async (s, e) => // handles marker click events
			{
				e.HideInfoWindow = true; // prevents the default info window from showing up

                bool viewDetails = await DisplayAlert( // instead displays a custom alert with the event details
					ev.title,
					$"{DateTimeConversionService.FormatDateAndTime(ev.date, ev.time)}",
					"View Details",
					"Cancel");
				
				if (viewDetails)
                //Passes the object as a dictionary to the EventDetailsViewModel via Shell navigation
                {
                    var navParams = new Dictionary<string, object>
					{
						{"Event", ev }
					};

					await Shell.Current.GoToAsync("eventdetails", navParams); //takes the paramters from the dictionary and adds them to the URI; that way if the user clicks on the "See Details" button, it will take them to that event's details page.
                }


			};
                ClosestEvents.Pins.Add(pin); // Adds the pin to the closest events list for display
		}

		var (userLocation, maxDistance) = await viewModel.GetLocationAndSpanData();

			ClosestEvents.MoveToRegion(MapSpan.FromCenterAndRadius(userLocation, Distance.FromMiles(maxDistance))); // specifies the center of the map and the radius to display


    }

    private async void OnRefreshClicked(object sender, EventArgs e)
	{
		await LoadMap(); // reloads the map with the closest events when the refresh button is clicked
    }
}