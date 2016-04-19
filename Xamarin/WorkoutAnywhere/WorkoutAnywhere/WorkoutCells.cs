using System;

using Foundation;
using UIKit;

namespace WorkoutAnywhere
{
	public partial class WorkoutCells : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("WorkoutCells");
		public static readonly UINib Nib;

		static WorkoutCells ()
		{
			Nib = UINib.FromName ("WorkoutCells", NSBundle.MainBundle);
		}

		public WorkoutCells (IntPtr handle) : base (handle)
		{
		}
	}
}
