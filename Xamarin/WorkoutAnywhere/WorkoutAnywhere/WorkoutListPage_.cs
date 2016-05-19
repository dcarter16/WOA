using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace WorkoutAnywhere
{
	partial class WorkoutListPage : UIViewController
	{
		private string label;
		private string[] workoutTitles;
		private string[] workoutURLs;
		public WorkoutListPage (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			List<string> temp = new List<string> ();
			temp.Add (label);
			List<Tuple<string, string>> workoutData = WorkoutManager.GetLabelList (temp);
			ReformatData (workoutData);
			WorkoutListTable.Source = new TableSource (workoutTitles, workoutURLs, this);
		}
		private void ReformatData(List<Tuple<string, string>> data){
			List<string> _urls = new List<string>();
			List<string> _titles = new List<string> ();
			for(int i = 0; i < data.Count; i++) {
				_urls.Add(data[i].Item1);
				_titles.Add (data[i].Item2);
			}
			workoutURLs = _urls.ToArray ();
			workoutTitles = _titles.ToArray ();
		}
		public void setLabel(string l){
			label = l.ToLower();
		}
		private class TableSource :UITableViewSource{
			protected string[] tableItems;
			protected string[] urls;
			protected string cellIdentifier = "TableCell";
			protected UIViewController parent; 
			public TableSource (string[] items, string[] _urls, UIViewController _parent){
				tableItems = items;
				urls = _urls;
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
				//GenericWorkoutPage workoutPageController = parent.Storyboard.InstantiateViewController("GenericWorkoutPage") as GenericWorkoutPage;
				//workoutPageController.setURL(urls[indexPath.Row]);
				//parent.NavigationController.PushViewController (workoutPageController, true);
				SampleWorkoutController workoutPageController = parent.Storyboard.InstantiateViewController("SampleWorkoutController") as SampleWorkoutController;
				workoutPageController.setURL (urls [indexPath.Row]);
				parent.NavigationController.PushViewController (workoutPageController, true);

				tableView.DeselectRow (indexPath, true);
			}
			public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath){


			}

		}
	}
}
