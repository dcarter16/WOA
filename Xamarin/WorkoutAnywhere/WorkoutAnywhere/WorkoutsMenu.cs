using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	partial class WorkoutsMenu : UITableViewController
	{
		protected string[] tableItems;
		public WorkoutsMenu (IntPtr handle) : base (handle)
		{
			
		}
		public override void ViewDidLoad(){
			base.ViewDidLoad ();
			NavBar.BringSubviewToFront (NavBar);
			WorkoutMenuTable = new UITableView (View.Bounds);
			Add (WorkoutMenuTable);
			tableItems  = WorkoutManager.GetLabelMenu();
			WorkoutMenuTable.Source = new TableSource (tableItems);
		}

		public class TableSource :UITableViewSource{
			protected string[] tableItems;
			protected string cellIdentifier = "TableCell";
			public TableSource (string[] items){
				tableItems = items;
			}
			public override nint RowsInSection(UITableView tableview, nint section){
				return tableItems.Length;
			}
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath){
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
				cell.TextLabel.Text = tableItems [indexPath.Row];
				return cell;
			}
		}
	}
}
