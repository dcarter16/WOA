using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	partial class ProfilePage : UIViewController
	{
		public ProfilePage (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Tuple<string, string> userInfo = UserDataManager.GetKeys ();
			UsernameText.Text = userInfo.Item1;
			PasswordText.Text = userInfo.Item2;
		}
	}
}
