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
	[Register ("ProfilePage")]
	partial class ProfilePage
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PasswordText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel UsernameText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (PasswordText != null) {
				PasswordText.Dispose ();
				PasswordText = null;
			}
			if (UsernameText != null) {
				UsernameText.Dispose ();
				UsernameText = null;
			}
		}
	}
}
