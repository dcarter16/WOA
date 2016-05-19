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
	partial class WorkoutListPage : UIViewController
	{
		
		protected string label;
		public WorkoutListPage(): base ()
		{
		}
		public void setLabels(string _label)
		{
			label = _label;
		}
	}
}
