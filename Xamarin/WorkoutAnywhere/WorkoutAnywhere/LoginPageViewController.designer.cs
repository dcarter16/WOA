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
	[Register ("LoginPageViewController")]
	partial class LoginPageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LoginButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PasswordText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SignupButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel tempText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton testButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UsernameText { get; set; }

		[Action ("LoginButtonClick:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void LoginButtonClick (UIButton sender);

		[Action ("tempTest:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void tempTest (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}
			if (PasswordText != null) {
				PasswordText.Dispose ();
				PasswordText = null;
			}
			if (SignupButton != null) {
				SignupButton.Dispose ();
				SignupButton = null;
			}
			if (tempText != null) {
				tempText.Dispose ();
				tempText = null;
			}
			if (testButton != null) {
				testButton.Dispose ();
				testButton = null;
			}
			if (UsernameText != null) {
				UsernameText.Dispose ();
				UsernameText = null;
			}
		}
	}
}
