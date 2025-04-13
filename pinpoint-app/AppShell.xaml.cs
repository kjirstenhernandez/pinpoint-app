using pinpoint_app.View;

namespace pinpoint_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventDetailsPage), typeof(EventDetailsPage)); // Registers the route for the EventDetailsPage
            Routing.RegisterRoute("eventdetails", typeof(EventDetailsPage));
            Routing.RegisterRoute("mapPage", typeof(MapPage));
            Routing.RegisterRoute("eventsPage", typeof(MainPage));

        }
    }
}
