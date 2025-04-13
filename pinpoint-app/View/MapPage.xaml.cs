using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace pinpoint_app.View;

public partial class MapPage : ContentPage
{
	private readonly MapViewModel viewModel;

	public MapPage(MapViewModel mapViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel = mapViewModel;
	}

	protected override async void OnAppearing()
	{
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

			pin.MarkerClicked += async (s, e) =>
			{
				e.HideInfoWindow = true;

				bool viewDetails = await DisplayAlert(
					ev.title,
					$"{ev.date}, {ev.time}",
					"View Details",
					"Cancel");
				
				if (viewDetails)
				{
					var navParams = new Dictionary<string, object>
					{
						{"Event", ev }
					};

					await Shell.Current.GoToAsync("eventdetails", navParams);
				}


			};
                ClosestEvents.Pins.Add(pin);
		}

		var (userLocation, maxDistance) = await viewModel.GetLocationAndSpanData();

			ClosestEvents.MoveToRegion(MapSpan.FromCenterAndRadius(userLocation, Distance.FromMiles(maxDistance)));

		
	}

    private async void OnRefreshClicked(object sender, EventArgs e)
	{
		await LoadMap();
	}
}