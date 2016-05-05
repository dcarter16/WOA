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
            Email.Placeholder = "Email";
            Email.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            
            UsernameChoice.Placeholder = "Username";
            UsernameChoice.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            PasswordChoice.Placeholder = "Password";
            PasswordChoice.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            PasswordConfirm.Placeholder = "Password";
            PasswordConfirm.ClearButtonMode = UITextFieldViewMode.WhileEditing;
		}
		public void trySubmit()
		{
			if(PasswordChoice.Text == PasswordConfirm.Text)
			{
				string email = Email.Text;
				string user = UsernameChoice.Text;
				string pass = PasswordChoice.Text;
				HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/AddUser.php?user=('" + user + "')&pass=('" + pass + "')&email=('" + email + "')") as HttpWebRequest;
				using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
					StreamReader reader = new StreamReader (response.GetResponseStream ());
					string result = reader.ReadLine ();
					//if (Convert.ToInt32(result) == 1)
						//tempText.Text = "New User Created";
					//else if (Convert.ToInt32(result) == 0)
						//tempText.Text = "Submission Failed";
					//else
						//tempText.Text = "ERROR";
					//tempText.Text += result;
				}
			}
		}
	}
}
