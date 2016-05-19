using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace WorkoutAnywhere
{
	partial class SampleWorkoutController : UIViewController
	{
		private string pageURL;
		private static WebClient client = new WebClient();
		private static Stream stream;
		private StreamReader reader;
		private static string line;
		private static List<Tuple<string, string>> pageDetails = new List<Tuple<string, string>> ();

		public SampleWorkoutController (IntPtr handle) : base (handle)
		{
		}
		public void setURL(string url){
			pageURL = url;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			stream = client.OpenRead (pageURL);
			reader = new StreamReader (stream);
			while ((line = reader.ReadLine()) != null)
			{
				if (line.Length > 0) {
					string[] words = line.Split('~');

					pageDetails.Add(new Tuple<string, string>(words[0], words[1]));
				}
			}

			foreach (Tuple<string, string> page in pageDetails) {
				switch (page.Item1.ToString()) {
				case "title":
					TitleLabel.Text = page.Item2.ToString ();
					break;
				case "detail":
					DetailLabel.Text = page.Item2.ToString ();
					break;
				case "step":
					StepLabel.Text += page.Item2.ToString ();
					break;
				case "video":
					string video = null;
					// SHOULD MAKE THIS A FUNCTION
					foreach(Tuple<string, string> pagepage in pageDetails) {
						if (pagepage.Item1.ToString() == "video") {
							video = pagepage.Item2.ToString();
							break;
						}
					}
					VideoLabel.LoadRequest (new NSUrlRequest (new NSUrl (video.ToString ())));
					VideoLabel.ScalesPageToFit = true;
					break;
				default:
					break;
				}
			}

		}

		partial void SampleSliderChanged (UISlider sender)
		{
			WorkoutAmount.Text = Convert.ToString(Math.Round(sender.Value)) + "%";
			//throw new NotImplementedException ();
		}

		partial void UIButton1438_TouchUpInside (UIButton sender)
		{
			string title = null;
			foreach(Tuple<string, string> page in pageDetails) {
				if (page.Item1.ToString() == "title") {
					title = page.Item2.ToString();
					break;
				}
			}

			// DOESN'T WORK
			client.DownloadFile("http://workoutanywhere.net/MobileData/Workouts/15-minute-outdoor-hiit-workout-workout-anywhere.txt", @"SavedWorkouts\test.txt");
		}
	}
}
