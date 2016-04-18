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
	[Register ("MainMenuPage")]
	partial class MainMenuPage
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CalendarButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CommunityButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton NutritionButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ProfileButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton WorkoutsButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CalendarButton != null) {
				CalendarButton.Dispose ();
				CalendarButton = null;
			}
			if (CommunityButton != null) {
				CommunityButton.Dispose ();
				CommunityButton = null;
			}
			if (NutritionButton != null) {
				NutritionButton.Dispose ();
				NutritionButton = null;
			}
			if (ProfileButton != null) {
				ProfileButton.Dispose ();
				ProfileButton = null;
			}
			if (WorkoutsButton != null) {
				WorkoutsButton.Dispose ();
				WorkoutsButton = null;
			}
		}
	}
}
