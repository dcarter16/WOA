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
	[Register ("SignUpP")]
	partial class SignUpP
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Email { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ErrorText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PasswordChoice { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PasswordConfirm { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton Signup { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UsernameChoice { get; set; }

		[Action ("Signup_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void Signup_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (Email != null) {
				Email.Dispose ();
				Email = null;
			}
			if (ErrorText != null) {
				ErrorText.Dispose ();
				ErrorText = null;
			}
			if (PasswordChoice != null) {
				PasswordChoice.Dispose ();
				PasswordChoice = null;
			}
			if (PasswordConfirm != null) {
				PasswordConfirm.Dispose ();
				PasswordConfirm = null;
			}
			if (Signup != null) {
				Signup.Dispose ();
				Signup = null;
			}
			if (UsernameChoice != null) {
				UsernameChoice.Dispose ();
				UsernameChoice = null;
			}
		}
	}
}
