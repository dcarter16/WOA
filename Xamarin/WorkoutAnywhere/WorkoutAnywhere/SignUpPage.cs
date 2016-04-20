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

		public void trySubmit (string email, string username, string password)
		{
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/AddUser.php?user=" + username + "&pass=" + password + "&email=" + email) as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
				StreamReader reader = new StreamReader (response.GetResponseStream ());
				string result = reader.ReadLine ();
				if (Convert.ToInt32 (result) == 1) {
					ErrorText.Text = "New User Created";
				} else if (Convert.ToInt32 (result) == 0) {
					ErrorText.Text = "Submission Failed";
				} else if (Convert.ToInt32 (result) == -1) {
					ErrorText.Text = "This email is already in use";
				}
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
	}
}
