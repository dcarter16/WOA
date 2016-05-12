using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Net;
using System.Text;
using System.IO;
using UIKit;

namespace WorkoutAnywhere
{
	partial class SignUpPage : UIViewController
	{
		public SignUpPage (IntPtr handle) : base (handle)
		{

		}

		private void trySubmit (string email, string username, string password)
		{
			string result = trySignUp (email, username, password);
			if (result == "0") {
				ErrorText.Text = "Submission Failed";
			} else if (result == "-1") {
				ErrorText.Text = "This email is already in use";
			} else{
				ErrorText.Text = "New User Created";
				UserDataManager.SetData(result);
				UserDataManager.SetPassword(password);
				UserDataManager.SaveKeys();
				GoToMainMenu ();
			}
		}
		private string trySignUp(string email, string username, string password){
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/AddUser.php?user=" + username + "&pass=" + password + "&email=" + email) as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
				StreamReader reader = new StreamReader (response.GetResponseStream ());
				return reader.ReadLine ();
			}
		}

		partial void Signup_TouchUpInside (UIButton sender)
		{
			if (PasswordChoice.Text == PasswordConfirm.Text) {
				trySubmit (Email.Text, UsernameChoice.Text, PasswordChoice.Text);
			} else {
				ErrorText.Text = "Passwords do not match.";			
			}
		}
		private void GoToMainMenu(){
			MainMenuPage mainMenuController = this.Storyboard.InstantiateViewController("MainMenuPage") as MainMenuPage;
			this.NavigationController.PushViewController (mainMenuController, true);
		}
	}
}
