using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CoreGraphics;

namespace WorkoutAnywhere
{
	partial class SampleWorkoutController : UIViewController
	{
		private string pageURL;
		public int step = 1;
		private WebClient client = new WebClient();
		private Stream stream;
		private StreamReader reader;
		private string line;
		private List<Tuple<string, string>> pageDetails = new List<Tuple<string, string>> ();

		public SampleWorkoutController (IntPtr handle) : base (handle)
		{
		}
		public void setURL(string url){
			pageURL = url;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			ReadFile ();

		}
		private void ReadFile(){
			string[] temp = pageURL.Split ('/');
			if (temp [0] == "http:")
				ReadFromServer ();
			else 
				ReadFromLocal ();

		}
		private void ReadFromLocal(){
			string filePath = Path.Combine (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SavedWorkouts/" + pageURL);
			string[] temp = System.IO.File.ReadAllLines (filePath);
			foreach (string s in temp) {
				string[] words = s.Split ('~');
				pageDetails.Add (new Tuple<string, string> (words [0], words [1]));
			}
			PopulatePage ();
		}
		private void ReadFromServer(){
			stream = client.OpenRead (pageURL);
			reader = new StreamReader (stream);
			while ((line = reader.ReadLine()) != null)
			{
				if (line.Length > 0) {
					string[] words = line.Split('~');

					pageDetails.Add(new Tuple<string, string>(words[0], words[1]));
				}
			}
			PopulatePage ();
		}
		private void PopulatePage(){
			foreach (Tuple<string, string> page in pageDetails) {
				switch (page.Item1.ToString()) {
				case "title":
					this.Title = page.Item2.ToString ();
					break;
//				DOESN'T WORK -- TEXT DOESN'T SHOW UP
//				case "step":
//					UILabel label = new UILabel (new CGRect(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height, UIScreen.MainScreen.Bounds.Width, 30));
//					label.Lines = 1;
//					if (Regex.IsMatch (page.Item2.ToString (), @"^\d")) {
//						label.Text = "\t" + page.Item2.ToString () + "\n";
//						label.Font.WithSize (18);
//					} else if (page.Item2.ToString ().StartsWith ("@")) {
//						label.Text = "\t" + page.Item2.ToString ().Substring (1) + "\n";
//						label.Font.WithSize (20);
//					} else {
//						label.Text = "\n" + step + ". " + page.Item2.ToString () + "\n";
//						label.Font.WithSize (24);
//						label.TextColor = UIColor.Blue;
//						step++;
//					}
//					this.View.AddSubview (label);
//					break;
				case "step":
					if (Regex.IsMatch (page.Item2.ToString (), @"^\d\.")) {
						StepLabel.Text += "\t" + page.Item2.ToString () + "\n";
					} else if (page.Item2.ToString ().StartsWith ("@")) {
						StepLabel.Text += "\t" + page.Item2.ToString ().Substring (1) + "\n";
					} else {
						StepLabel.Text += "\n" + step + ". " + page.Item2.ToString () + "\n";
						step++;
					}
					break;
				case "video":
					string video = null;
					video = findValuebyKey("video");
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
		}

		partial void UIButton1438_TouchUpInside (UIButton sender)
		{
			string[] temp = pageURL.Split('/');
			string title = temp[temp.Length -1];

			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			if (!Directory.Exists(documents + "/SavedWorkouts")) {
				var directoryname = Path.Combine (documents, "SavedWorkouts");
				Directory.CreateDirectory(directoryname);
			}

			client.DownloadFile(pageURL, documents + "/SavedWorkouts/" + title );
		}

		private string findValuebyKey(string key) {
			string value = null;
			foreach(Tuple<string, string> page in pageDetails) {
				if (page.Item1.ToString() == key) {
					value = page.Item2.ToString();
					break;
				}
			}
			return value;
		}
	}
}
