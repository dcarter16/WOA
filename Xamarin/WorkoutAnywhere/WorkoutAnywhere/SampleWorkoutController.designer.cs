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
		UILabel DetailLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SampleWorkoutAmount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider SampleWorkoutSlider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView SampleWorkoutView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel StepLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIWebView VideoLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel WorkoutAmount { get; set; }

		[Action ("SampleSliderChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SampleSliderChanged (UISlider sender);

		[Action ("UIButton1438_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UIButton1438_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (DetailLabel != null) {
				DetailLabel.Dispose ();
				DetailLabel = null;
			}
			if (SampleWorkoutAmount != null) {
				SampleWorkoutAmount.Dispose ();
				SampleWorkoutAmount = null;
			}
			if (SampleWorkoutSlider != null) {
				SampleWorkoutSlider.Dispose ();
				SampleWorkoutSlider = null;
			}
			if (SampleWorkoutView != null) {
				SampleWorkoutView.Dispose ();
				SampleWorkoutView = null;
			}
			if (StepLabel != null) {
				StepLabel.Dispose ();
				StepLabel = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
			if (VideoLabel != null) {
				VideoLabel.Dispose ();
				VideoLabel = null;
			}
			if (WorkoutAmount != null) {
				WorkoutAmount.Dispose ();
				WorkoutAmount = null;
			}
		}
	}
}
