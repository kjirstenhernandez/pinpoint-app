namespace pinpoint_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventDetailsPage), typeof(EventDetailsPage)); // Registers the route for the EventDetailsPage
        }
    }
}
