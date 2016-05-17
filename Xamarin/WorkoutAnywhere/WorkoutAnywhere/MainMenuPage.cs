using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WorkoutAnywhere
{
	partial class MainMenuPage : UIViewController
	{
		public MainMenuPage (IntPtr handle) : base (handle) 
		{
			

		
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UIGraphics.BeginImageContext (this.View.Frame.Size);
			UIImage i = UIImage.FromFile (@"BackgroundImages/fon-36630.jpg");
			i = i.Scale (this.View.Frame.Size);
			this.View.BackgroundColor = UIColor.FromPatternImage(i);
			ProfileButton.SetTitle(String.Format("{0}", UserDataManager.getDisplayName()), UIControlState.Normal);
			//ParentViewController.NavigationItem.SetHidesBackButton(true, false);
		}
		partial void WorkoutsButton_TouchUpInside (UIButton sender)
		{
			WorkoutClassPage workoutClassController = this.Storyboard.InstantiateViewController("WorkoutClassPage") as WorkoutClassPage;
			this.NavigationController.PushViewController (workoutClassController, true);
		}
		partial void NutritionButton_TouchUpInside (UIButton sender)
		{
			NutritionPage nutritionController = this.Storyboard.InstantiateViewController("NutritionPage") as NutritionPage;
			this.NavigationController.PushViewController (nutritionController, true);
		}
		partial void CalendarButton_TouchUpInside (UIButton sender)
		{
			CalendarPage calendarController = this.Storyboard.InstantiateViewController("CalendarPage") as CalendarPage;
			this.NavigationController.PushViewController (calendarController, true);
		}
		partial void CommunityButton_TouchUpInside (UIButton sender)
		{
			SampleWorkoutController communityController = this.Storyboard.InstantiateViewController("SampleWorkoutController") as SampleWorkoutController;
			this.NavigationController.PushViewController (communityController, true);
		}
		partial void ProfileButton_TouchUpInside (UIButton sender)
		{
			ProfilePage profileController = this.Storyboard.InstantiateViewController("ProfilePage") as ProfilePage;
			this.NavigationController.PushViewController (profileController, true);
		}
		public void ViewWorkoutButton_TouchInside(UIButton sender){
			SampleWorkoutController workoutController = this.Storyboard.InstantiateViewController("SampleWorkoutController") as SampleWorkoutController;
			this.NavigationController.PushViewController (workoutController, true);
		}
	}
}
