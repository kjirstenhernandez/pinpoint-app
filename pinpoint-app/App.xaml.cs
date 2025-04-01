namespace pinpoint_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); //loading the XAML resources
        }

        protected override Window CreateWindow(IActivationState activationState)  // Apparently AppShell is outmoded, so this is the new way to do it
        {
            var window = new Window(new AppShell()); // creates a window with AppShell as the root
            Routing.RegisterRoute(nameof(EventDetailsPage), typeof(EventDetailsPage));  //registers route with MAUI
            return window;
        }
    }
}


