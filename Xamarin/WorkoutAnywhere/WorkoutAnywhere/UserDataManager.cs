using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Security;
using Foundation;
using Xamarin.Auth;

namespace WorkoutAnywhere
{
    public static class UserDataManager
    {
		private static string userEmail;
		private static string userPassword;
		private static string userName;
		private static string userDisplayName;

	    private static bool member; //for future use; when adding member dependent functionality

	    //when the app is initialzied, all fields are set to blank strings
	    public static void Initialize(){
	        userEmail = "";
	        userPassword = "";
	        userName = "";
	        userDisplayName = "";
	    }

	    //from the returned json gotten from the login script, set the fields 
	    //that were initially set to blank
	    //used for displaying user information in profile section and on homepage
		public static void SetData(string dataString){
				var user = JObject.Parse(dataString);
				userEmail = user["user_email"].ToString();
				userName = user["user_login"].ToString();
				userDisplayName = user["display_name"].ToString();
				if (user["user_activation_key"].ToString() != "")
					member = true;
				else
					member = false;
		}
		public static void SetPassword(string password)
		{
			userPassword = password;
		}
	    public static string getDisplayName(){return userDisplayName;}

	    //functions used for saving keys to keychain
		public static void SaveKeys()
		{
			var s = new SecRecord (SecKind.GenericPassword) {
				Server = "workoutanywhere.com",
				Label = "Username",
				Account = "WorkoutAnywhere",
				Generic = NSData.FromString ( userName, NSStringEncoding.UTF8 )
			};
			var err = SecKeyChain.Add(s);
			s = new SecRecord (SecKind.GenericPassword) {
				Server = "workoutanywhere.com",
				Label = "Password",
				Account = "WorkoutAnywhere",
				Generic = NSData.FromString ( userPassword, NSStringEncoding.UTF8 )
			};
			err = SecKeyChain.Add (s);
		}		
		public static Tuple<string, string> GetKeys()
		{
			var query = new SecRecord (SecKind.GenericPassword) {
				Server = "workoutanywhere.com",
				Label = "Username",
				Account = "WorkoutAnywhere",
			};
			SecStatusCode code;
			var username = SecKeyChain.QueryAsData(query);
			//Console.WriteLine (code);
			query = new SecRecord (SecKind.GenericPassword) {
				Server = "workoutanywhere.com",
				Label = "Password",
				Account = "WorkoutAnywhere",
			};

			var password = SecKeyChain.QueryAsData (query);
			//Console.WriteLine (code);
			return new Tuple<string, string> (username.ToString(), password.ToString());
		}

		//Xamarin.Auth Attempt at using the keychain
		public static void SaveCredentials(string username, string password){
			if (!string.IsNullOrWhiteSpace (username) && !string.IsNullOrWhiteSpace (password)) {
				Account account = new Account ();
				account.Username = username;
				account.Properties.Add("Password", password);
				AccountStore.Create ().Save (account, "WorkoutAnywhere");
			}
		}

    }
}



