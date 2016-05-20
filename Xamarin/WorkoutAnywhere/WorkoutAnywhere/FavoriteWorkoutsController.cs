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
		private List<string> titles = new List<string>();
		private List<string> fileNames = new List<string>();
		public FavoriteWorkoutsController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			GetSavedFiles ();
			FavoriteMenuTable.Source = new TableSource (titles, fileNames, this);
		}
		private void GetSavedFiles(){
			string path = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + "/SavedWorkouts";
			if (Directory.Exists (path)) {
				var directories = Directory.EnumerateFiles (path);
				foreach (var dir in directories) {
					fileNames.Add(Path.GetFileName (path + "/" + dir));
					string[] temp = fileNames.Last ().Split ('/');
					titles.Add(WorkoutManager.GetTitle(temp.Last()));
				}
			}
			else {
				//TestLabel.Text = "You have no saved workouts.";
			}
		}
		private class TableSource :UITableViewSource{
			protected string[] tableItems;
			protected string[] files;
			protected string cellIdentifier = "TableCell";
			protected UIViewController parent; 
			public TableSource (List<string> items, List<string> _files, UIViewController _parent){
				tableItems = items.ToArray();
				files = _files.ToArray();
				parent = _parent;
			}
			public override nint RowsInSection(UITableView tableview, nint section){
				return tableItems.Length;
			}
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath){
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Value1, cellIdentifier);
				cell.TextLabel.Text = tableItems[indexPath.Row];
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				return cell;
			}
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath){
				SampleWorkoutController workoutController = parent.Storyboard.InstantiateViewController("SampleWorkoutController") as SampleWorkoutController;
				workoutController.setURL(files[indexPath.Row]);
				parent.NavigationController.PushViewController (workoutController, true);
				tableView.DeselectRow (indexPath, true);
			}
		}
	}
}
