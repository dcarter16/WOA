using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	partial class SampleWorkoutController : UIViewController
	{
		public SampleWorkoutController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SampleWorkoutVideo.LoadRequest (new NSUrlRequest (new NSUrl ("https://www.youtube.com/embed/c-5bQaDtwE0")));
			SampleWorkoutVideo.ScalesPageToFit = true;
		}

		partial void SampleSliderChanged (UISlider sender)
		{
			SampleWorkoutAmount.Text = Convert.ToString(Math.Round(sender.Value));
			//throw new NotImplementedException ();
		}
	}
}
