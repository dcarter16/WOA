using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	partial class WorkoutPage : UIViewController
	{
		private string pageUrl;
		public WorkoutPage (IntPtr handle) : base (handle)
		{
			
		}
		public void setURL(string _url)
		{
			pageUrl = _url;
		}
	}
}
