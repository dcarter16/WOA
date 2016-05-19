using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	partial class GenericWorkoutPage : UIViewController
	{
		private string pageUrl;
		public GenericWorkoutPage (IntPtr handle) : base (handle)
		{
		}

		public void setURL(string _url)
		{
			pageUrl = _url;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			urlLabel.Text = pageUrl;
		}
	}
}
