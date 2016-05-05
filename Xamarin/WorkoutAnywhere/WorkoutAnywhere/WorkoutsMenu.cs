using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutAnywhere
{
	partial class WorkoutsMenu : UITableViewController
	{
		protected List<Tuple<string, int>> tableItems;
		protected string[] titles;
		protected string[] counts;
		public WorkoutsMenu (IntPtr handle) : base (handle)
		{
			
		}
		public override void ViewDidLoad(){
			base.ViewDidLoad ();
			WorkoutMenuTable = new UITableView (View.Bounds);
			Add (WorkoutMenuTable);
			tableItems  = WorkoutManager.GetLabelMenu();
			ReformatData ();
			WorkoutMenuTable.Source = new TableSource (titles, counts);
		}
		private void ReformatData(){
			List<string> _titles = new List<string>();
			List<string> _counts = new List<string> ();
			for(int i = 0; i < tableItems.Count; i++)
			{
				_titles.Add(tableItems[i].Item1);
				_counts.Add(tableItems[i].Item2.ToString());
			}
			titles = _titles.ToArray();
			counts = _counts.ToArray();
		}
		public class TableSource :UITableViewSource{
			protected string[] tableItems;
			protected string[] itemCounts;
			protected string cellIdentifier = "TableCell";
			public TableSource (string[] items, string[] counts){
				tableItems = items;
				itemCounts = counts;
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
				return cell;
			}
		}
	}
}