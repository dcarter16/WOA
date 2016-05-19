using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreGraphics;

namespace WorkoutAnywhere
{
	partial class WorkoutClassPage : UIViewController
	{
		protected List<Tuple<string, int>> tableItems;
		protected string[] titles;
		protected string[] counts;
		public WorkoutClassPage (IntPtr handle) : base (handle)
		{
			/*nfloat ViewSize = View.Bounds.Size.Width;
			WorkoutMenuTable.ContentSize.Width.Equals(ViewSize);*/
			//Tried to set the menu to fill the screen but nothing I tried worked. Above is one example I found of what might work
		}
		public override void ViewDidLoad(){
			base.ViewDidLoad ();
			tableItems  = WorkoutManager.GetLabelMenu();
			ReformatData ();
			WorkoutMenuTable.Source = new TableSource (titles, counts, this);
			WorkoutListPage workoutListController = this.Storyboard.InstantiateViewController("WorkoutListPage") as WorkoutListPage;
			//workoutListController.setLabels(tableItems[indexPath.Row]);
			this.NavigationController.PushViewController (workoutListController, true);
		}

		private void ReformatData(){
			List<string> _titles = new List<string>();
			List<string> _counts = new List<string> ();
			for(int i = 0; i < tableItems.Count; i++)
			{
				_titles.Add(tableItems[i].Item1.Substring(0,1).ToUpper() + tableItems[i].Item1.Substring(1, tableItems[i].Item1.Length-1));
				_counts.Add(tableItems[i].Item2.ToString());
			}
			titles = _titles.ToArray();
			counts = _counts.ToArray();

		}
		public class TableSource :UITableViewSource{
			protected string[] tableItems;
			protected string[] itemCounts;
			protected string cellIdentifier = "TableCell";
			protected UIViewController parent; 
			public TableSource (string[] items, string[] counts, UIViewController _parent){
				tableItems = items;
				itemCounts = counts;
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
				cell.DetailTextLabel.Text = itemCounts[indexPath.Row];
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				return cell;
			}
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath){
				//UIAlertController alertController = UIAlertController.Create ("Row Selected", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);	
				//alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				//parent.PresentViewController (alertController, true, null);
				WorkoutListPage workoutListController = parent.Storyboard.InstantiateViewController("WorkoutListPage") as WorkoutListPage;
				workoutListController.setLabels(tableItems[indexPath.Row]);
				parent.NavigationController.PushViewController (workoutListController, true);
				tableView.DeselectRow (indexPath, true);
			}
			public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath){


			}

		}
	}
}
