namespace pinpoint_app.ViewModel;

public partial class BaseEventViewModel : ObservableObject
{
    [ObservableProperty]  // Makes isBusy property observable, so that any changes are reflected in the UI
    [NotifyPropertyChangedFor(nameof(IsNotBusy))] // If isBusy changes, IsNotBusy is also updated
    bool isBusy;

    [ObservableProperty] // the UI is updated when the Title property changes
    string title;

    public bool IsNotBusy => !IsBusy; // returns the opposite of isBusy
}