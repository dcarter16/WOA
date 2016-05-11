using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WorkoutAnywhere
{
    public static class UserDataManager
    {
    private static string userEmail { get; set; }
    private static string userPassword { get; set ;}
    private static string userName { get; set; }
    private static string userFullName { get; set; }

    private static bool member; //for future use; when adding member dependent functionality

    public static void Initialize(){
        userEmail = "";
        userPassword = "";
        userName = "";
        userFullName = "";
    }
	public static void SetData(string dataString){
		}
    public static void SetData(string username, string password){	//use for loginpage
        userName = username;
        userPassword = password;
        }
    public static void SetName(string email, string fName){
        userEmail = email;
        userFullName = fName;
        }
    public static void SetData(string uName, string fName, string email, string password){	//used for signup page
        userName = uName;
        userFullName = fName;
        userEmail = email;
        userPassword = password;
        }

    }
}



