using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WorkoutAnywhere
{
    public static class UserDataManager
    {
    private static string userEmail { get; set; }
    private static string userPassword { get; set ;}
    private static string userName { get; set; }
    private static string userDisplayName { get; set; }
		private static string userKey = "asdfasdgasdgfasasdfasdf";
		private static string passKey = "Asdfaghfabsdfasdf";

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
			userPassword = user["user_pass"].ToString();
			userName = user["user_login"].ToString();
			userDisplayName = user["display_name"].ToString();
			if (user["user_activation_key"].ToString() != "")
				member = true;
			else
				member = false;
	}
    public static string getDisplayName(){return userDisplayName;}

		public static void SaveKeys()
		{

		}		

    }
}



