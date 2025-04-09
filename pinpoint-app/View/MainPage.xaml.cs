

namespace pinpoint_app.View;

public partial class MainPage : ContentPage
{
    public MainPage(EventsViewModel eventsViewModel)
    {
        InitializeComponent();
        BindingContext = eventsViewModel; // Binds the EventsViewModel to the UI, including the activity indicator and the list of events.
    }

}
