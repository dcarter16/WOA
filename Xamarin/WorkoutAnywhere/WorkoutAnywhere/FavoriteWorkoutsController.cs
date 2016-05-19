using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAnywhere
{
	partial class FavoriteWorkoutsController : UIViewController
	{
		private List<string> favoritedWorkouts = new List<string> ();
		public FavoriteWorkoutsController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			string path = @"SavedWorkouts/.";
			string temp = "CD====" +Environment.CurrentDirectory;
			var directories = System.IO.Directory.EnumerateFiles(Environment.CurrentDirectory);
			foreach (var dir in directories) {
				Console.WriteLine (dir);
			}
		}
	}
}
