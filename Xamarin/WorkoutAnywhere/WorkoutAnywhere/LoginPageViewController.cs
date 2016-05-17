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
			NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(69,150,232);
			NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes () { ForegroundColor = UIColor.White };
			//NavigationController.NavigationItem.BackBarButtonItem.TintColor = UIColor.LightGray;
			UsernameText.Text = UserDataManager.UserName;
			PasswordText.Text = UserDataManager.Password;
		}
		partial void SignUpClick (UIButton sender)
		{
			SignUpPage signUpClickController = this.Storyboard.InstantiateViewController("SignUpPage") as SignUpPage;
			this.NavigationController.PushViewController (signUpClickController, true);
		}

		partial void LoginButtonClick (UIButton sender)
		{
			string result = tryLogin(UsernameText.Text, PasswordText.Text);
			if(result == "0") {
				ErrorText.Text = "Log In Failed";
			}else{
				ErrorText.Text = "Logged In";
				UserDataManager.SetData(result);
				UserDataManager.SetPassword(PasswordText.Text);
				UserDataManager.SaveCredentials();
				GoToMainMenu();
			}
		}
		public string tryLogin(string username, string password)
		{
			HttpWebRequest request = WebRequest.Create ("http://workoutanywhere.net/DatabaseConnection_iOS_App/PDOUserLogin.php?user=" + username + "&pass=" + password) as HttpWebRequest;
			using (HttpWebResponse response = request.GetResponse () as HttpWebResponse) {
			StreamReader reader = new StreamReader (response.GetResponseStream ());
				return (reader.ReadLine ());      
			}                                           
		}
		private void GoToMainMenu(){
			MainMenuPage mainMenuController = this.Storyboard.InstantiateViewController("MainMenuPage") as MainMenuPage;
			this.NavigationController.PushViewController (mainMenuController, true);
		}

	}
}
