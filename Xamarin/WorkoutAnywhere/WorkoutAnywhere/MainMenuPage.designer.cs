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
		UIButton FavoritesButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UINavigationItem NavBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton NutritionButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ProfileButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton WorkoutsButton { get; set; }

		[Action ("CalendarButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CalendarButton_TouchUpInside (UIButton sender);

		[Action ("FavoritesButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void FavoritesButton_TouchUpInside (UIButton sender);

		[Action ("NutritionButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void NutritionButton_TouchUpInside (UIButton sender);

		[Action ("ProfileButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ProfileButton_TouchUpInside (UIButton sender);

		[Action ("WorkoutsButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void WorkoutsButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CalendarButton != null) {
				CalendarButton.Dispose ();
				CalendarButton = null;
			}
			if (FavoritesButton != null) {
				FavoritesButton.Dispose ();
				FavoritesButton = null;
			}
			if (NavBar != null) {
				NavBar.Dispose ();
				NavBar = null;
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
