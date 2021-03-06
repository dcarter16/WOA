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
			UIImage i = UIImage.FromFile (@"BackgroundImages/bg3.jpg");
			i = i.Scale (this.View.Frame.Size);
			this.View.BackgroundColor = UIColor.FromPatternImage(i);
			ProfileButton.SetTitle(String.Format("{0}", UserDataManager.getDisplayName()), UIControlState.Normal);
			NavigationItem.SetHidesBackButton(true, false);
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
			NutritionPage nutritionController = this.Storyboard.InstantiateViewController("NutritionPage") as NutritionPage;
			nutritionController.Title = "Calendar";
			this.NavigationController.PushViewController (nutritionController, true);
			//CalendarPage calendarController = this.Storyboard.InstantiateViewController("CalendarPage") as CalendarPage;
			//this.NavigationController.PushViewController (calendarController, true);
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

		partial void FavoritesButton_TouchUpInside (UIButton sender)
		{
				FavoriteWorkoutsController favoriteWorkoutsController = this.Storyboard.InstantiateViewController ("FavoriteWorkoutsController") as FavoriteWorkoutsController;
				this.NavigationController.PushViewController (favoriteWorkoutsController, true);
		}
	}
}
