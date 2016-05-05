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
			SignUpPage signUpClickController = this.Storyboard.InstantiateViewController("SignUpPage") as SignUpPage;
			this.NavigationController.PushViewController (signUpClickController, true);
		}

		partial void LoginButtonClick (UIButton sender)
		{
			int result = tryLogin(UsernameText.Text, PasswordText.Text);
			if (result == 1) {
				ErrorText.Text = "Logged In";
				GoToMainMenu();
			} else if (result == 0) {
				ErrorText.Text = "Log In Failed";
			} else {
				ErrorText.Text = "ERROR";
			}
		}
		public int tryLogin(string username, string password)
		{
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/PDOUserLogin.php?user=('" + username + "')&pass=('" + password + "')") as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
			StreamReader reader = new StreamReader (response.GetResponseStream ());
				return Convert.ToInt32(reader.ReadLine ());      
			}                                           
		}
		public void GoToMainMenu(){
			MainMenuPage mainMenuController = this.Storyboard.InstantiateViewController("MainMenuPage") as MainMenuPage;
			this.NavigationController.PushViewController (mainMenuController, true);
		}

	}
}
