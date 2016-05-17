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

		private void trySubmit (string email, string username, string password, string firstname, string lastname)
		{
			string result = trySignUp (email, username, password, String.Format("{0} {1}", firstname, lastname));
			if (result == "0") {
				ErrorText.Text = "Submission Failed";
			} else if (result == "-1") {
				ErrorText.Text = "This email is already in use";
			} else{
				ErrorText.Text = "New User Created";
				UserDataManager.SetData(result);
				UserDataManager.SetPassword(password);
				UserDataManager.SaveCredentials();
				GoToMainMenu ();
			}
		}
		private string trySignUp(string email, string username, string password, string fullName){
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/PDOAddUser.php?user=" + username + "&pass=" + password + "&email=" + email + "&name=" + fullName) as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
				StreamReader reader = new StreamReader (response.GetResponseStream ());
				return reader.ReadLine ();
			}
		}

		partial void Signup_TouchUpInside (UIButton sender)
		{
			if(Email.Text == "" || UsernameChoice.Text == "" || PasswordChoice.Text == "" || FirstNameChoice.Text == "" || LastNameChoice.Text ==""){
				ErrorText.Text = "Please fill all fields.";
			}else if (PasswordChoice.Text == PasswordConfirm.Text) {
				trySubmit (Email.Text, UsernameChoice.Text, PasswordChoice.Text, FirstNameChoice.Text, LastNameChoice.Text);
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
