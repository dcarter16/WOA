// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	[Register ("SampleWorkoutController")]
	partial class SampleWorkoutController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SampleSubmitButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SampleWorkoutAmount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider SampleWorkoutSlider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIWebView SampleWorkoutVideo { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView SampleWorkoutView { get; set; }

		[Action ("SampleSliderChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SampleSliderChanged (UISlider sender);

		void ReleaseDesignerOutlets ()
		{
			if (SampleSubmitButton != null) {
				SampleSubmitButton.Dispose ();
				SampleSubmitButton = null;
			}
			if (SampleWorkoutAmount != null) {
				SampleWorkoutAmount.Dispose ();
				SampleWorkoutAmount = null;
			}
			if (SampleWorkoutSlider != null) {
				SampleWorkoutSlider.Dispose ();
				SampleWorkoutSlider = null;
			}
			if (SampleWorkoutVideo != null) {
				SampleWorkoutVideo.Dispose ();
				SampleWorkoutVideo = null;
			}
			if (SampleWorkoutView != null) {
				SampleWorkoutView.Dispose ();
				SampleWorkoutView = null;
			}
		}
	}
}
