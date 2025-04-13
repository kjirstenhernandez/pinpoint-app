using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;

namespace pinpoint_app.Behaviors
{
    public class ClipBehavior : Behavior<Border>
    //Creates a behavior that can be attached to a border element,
    // clipping the edges of the border to create a rounded rectangle effect 
    // that matches the size of the border.
    {
        protected override void OnAttachedTo(Border bindable)
        //attaching the behavior to the Border
        {
            base.OnAttachedTo(bindable); // executing any setup code from the base class
            bindable.SizeChanged += OnSizeChanged; //subscribing the OnSizeChanged method to the SizeChanged event
                                                   //event triggers with any change of size in the Border
        }

        protected override void OnDetachingFrom(Border bindable)
        //detaching the behavior from the Border
        {
            base.OnDetachingFrom(bindable); //cleans up the base behavioro class
            bindable.SizeChanged -= OnSizeChanged; // cleaning up by unsubscribing
        }

        private void OnSizeChanged(object sender, EventArgs e)
        //method that handles the SizeChanged event
        {
            if (sender is Border border && border.Width > 0 && border.Height > 0)
            {
                border.Clip = new RectangleGeometry
                {
                    Rect = new Rect(0, 0, border.Width, border.Height)
                };
            }
        }
    }
}
