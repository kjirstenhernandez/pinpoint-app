namespace pinpoint_app.ViewModel;
[QueryProperty(nameof(EventItem), "Event")] // for shell navigation, passes an event object
public partial class EventDetailsViewModel : BaseEventViewModel
{
	public  EventDetailsViewModel()
	{
		
	}

	[ObservableProperty] // UI is bound to this property when the EventItem is updated.
    Event eventItem;
}