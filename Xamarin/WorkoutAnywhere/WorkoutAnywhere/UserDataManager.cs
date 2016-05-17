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

		public static string getUserName () {
			return userName;
		}

		public static string getUserPassword () {
			return userPassword;
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

		//Xamarin.Auth Attempt at using the keychain
		public static void SaveCredentials( ){
			if (!string.IsNullOrWhiteSpace (userName) && !string.IsNullOrWhiteSpace (userPassword)) {
				Account account = new Account ();
				account.Username = userName;
				account.Properties.Add("Password", userPassword);
				AccountStore.Create ().Save (account, "WorkoutAnywhere");
			}
		}

		public static string UserName {
			get {
				var account = AccountStore.Create ().FindAccountsForService ("WorkoutAnywhere").FirstOrDefault ();
				return (account != null) ? account.Username : null;
			}
		}

		public static string Password {
			get {
				var account = AccountStore.Create ().FindAccountsForService ("WorkoutAnywhere").FirstOrDefault ();
				return (account != null) ? account.Properties ["Password"] : null;
			}
		}
    }
}



