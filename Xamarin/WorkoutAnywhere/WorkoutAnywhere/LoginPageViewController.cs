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
		partial void LoginButtonClick (UIButton sender)
		{
			tryLogin();
		}
		partial void tempTest (UIButton sender)
		{
			tryLogin();
		}
		public void tryLogin()
		{
			string username = UsernameText.Text;
			string password = PasswordText.Text;
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/connection.php?user=('" + username + "')&pass=('" + password + "')") as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
			StreamReader reader = new StreamReader (response.GetResponseStream ());
				string result = reader.ReadLine ();      
				if (Convert.ToInt32(result) == 1)
					tempText.Text = "Logged In";
				else if (Convert.ToInt32(result) == 0)
					tempText.Text = "Log In Failed";
				else
					tempText.Text = "ERROR";
				tempText.Text += result;                
			}                                           
		}	  
	}
}
