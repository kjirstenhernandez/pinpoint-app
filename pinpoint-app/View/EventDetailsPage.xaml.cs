namespace pinpoint_app;

public partial class EventDetailsPage : ContentPage
{
    public EventDetailsPage(EventDetailsViewModel viewModel)

    {
        InitializeComponent();
        BindingContext = viewModel;
    }



}
