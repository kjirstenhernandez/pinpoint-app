using pinpoint_app.View;

namespace pinpoint_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventDetailsPage), typeof(EventDetailsPage)); // Registers another route for the EventDetailsPage
            Routing.RegisterRoute("eventdetails", typeof(EventDetailsPage)); // Registers route for the EventDetailsPage
            Routing.RegisterRoute("mapPage", typeof(MapPage)); // Registers the route for the MapPage
            Routing.RegisterRoute("eventsPage", typeof(MainPage)); // Registers the route for the MainPage

        }
    }
}
