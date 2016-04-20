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
		UIViewController mainMenuController;
		public LoginPageViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		public void Initialize(){
		}
		partial void LoginButtonClick (UIButton sender)
		{
			tryLogin(UsernameText.Text, PasswordText.Text);
		}

		public void tryLogin(string username, string password)
		{

			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/connection.php?user=" + username + "&pass=" + password) as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
			StreamReader reader = new StreamReader (response.GetResponseStream ());
				string result = reader.ReadLine ();
				if (Convert.ToInt32 (result) == 1) {
					tempText.Text = "Logged In";
					// move to main menu page
					GoToMainMenu();
				} else if (Convert.ToInt32 (result) == 0) {
					tempText.Text = "Log In Failed";
				} else {
					tempText.Text = "ERROR";
				}
			}
		}
		public void GoToMainMenu(){
			mainMenuController = Storyboard.InstantiateViewController ("MainMenuController") as MainMenuController;
			this.NavigationController.PushViewController (mainMenuController, true);
		}
	}
}
