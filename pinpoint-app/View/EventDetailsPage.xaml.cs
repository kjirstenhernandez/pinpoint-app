namespace pinpoint_app;

public partial class EventDetailsPage : ContentPage
{
    public EventDetailsPage(EventDetailsViewModel viewModel)
    // Takes the EventDetailsViewModel instance and binds it to the UI
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
