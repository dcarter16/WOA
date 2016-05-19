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
			UsernameText.Text = UserDataManager.getUserName ();
			PasswordText.Text = UserDataManager.getUserPassword ();
		}

		partial void LogoutButton_TouchUpInside (UIButton sender)
		{
			//throw new NotImplementedException ();
			UserDataManager.isLoggedOut = true;
			LoginPageViewController loginController = this.Storyboard.InstantiateViewController("LoginPageViewController") as LoginPageViewController;
			this.NavigationController.PushViewController (loginController, true);
		}
	}
}
