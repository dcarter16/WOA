using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Net;
using System.Text;
using System.IO;
using UIKit;

namespace WorkoutAnywhere
{
	partial class LoginPageViewController : UIViewController
	{
		public LoginPageViewController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad(){
			base.ViewDidLoad ();
		}

		partial void SignUpClick (UIButton sender)
		{
			SignUpController signUpClickController = this.Storyboard.InstantiateViewController("SignUpController") as SignUpController;
			this.NavigationController.PushViewController (signUpClickController, true);
		}

		partial void LoginButtonClick (UIButton sender)
		{
			int result = tryLogin(UsernameText.Text, PasswordText.Text);
			if (result == 1) {
				tempText.Text = "Logged In";
				// move to main menu page
				GoToMainMenu();
			} else if (result == 0) {
				tempText.Text = "Log In Failed";
			} else {
				tempText.Text = "ERROR";
			}
		}

		public int tryLogin(string username, string password)
		{
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/connection.php?user=" + username + "&pass=" + password) as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
			StreamReader reader = new StreamReader (response.GetResponseStream ());
				string result = reader.ReadLine ();
				return Convert.ToInt32 (result);
			}
		}
		public void GoToMainMenu(){
			MainMenuController mainMenuController = this.Storyboard.InstantiateViewController("MainMenuController") as MainMenuController;
			this.NavigationController.PushViewController (mainMenuController, true);
		}
	}
}
