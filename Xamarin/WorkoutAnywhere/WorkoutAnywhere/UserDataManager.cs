using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Security;
using Foundation;

namespace WorkoutAnywhere
{
    public static class UserDataManager
    {
		private static string userEmail;
		private static string userPassword;
		private static string userName;
		private static string userDisplayName;

	    private static bool member; //for future use; when adding member dependent functionality

	    public static void Initialize(){
	        userEmail = "";
	        userPassword = "";
	        userName = "";
	        userDisplayName = "";
	    }
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
    }
}



