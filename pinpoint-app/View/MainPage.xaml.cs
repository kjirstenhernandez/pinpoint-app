

namespace pinpoint_app.View;

public partial class MainPage : ContentPage
{
    public MainPage(EventsViewModel eventsViewModel)
    {
        InitializeComponent();
        BindingContext = eventsViewModel;
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    // Reacts to the tap on an event from the list, loading the Event Details page. 
    {
        var eventItem = ((VisualElement)sender).BindingContext as Event;

        if (eventItem == null)
            return;

        await Shell.Current.GoToAsync(nameof(EventDetailsPage), true, new Dictionary<string, object> // passes the parameters to the EventDetailsPage 
        {
            {"Event", eventItem }
        });
    }

}
