using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WorkoutAnywhere
{
	partial class SampleWorkoutController : UIViewController
	{
		private string pageURL;
<<<<<<< HEAD
		private static WebClient client = new WebClient();
		private static Stream stream;
		private StreamReader reader;
		private static string line;
		private static List<Tuple<string, string>> pageDetails = new List<Tuple<string, string>> ();
=======
		public int step = 1;
		private WebClient client = new WebClient();
		private Stream stream;
		private StreamReader reader;
		private string line;
		private List<Tuple<string, string>> pageDetails = new List<Tuple<string, string>> ();
>>>>>>> master

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
					this.Title = page.Item2.ToString ();
					break;
				case "step":
					if (Regex.IsMatch (page.Item2.ToString (), @"^\d")) {
						StepLabel.Text += "\t" + page.Item2.ToString () + "\n";
					}
					else if (page.Item2.ToString().StartsWith("@")) {
						StepLabel.Text += "\t" + page.Item2.ToString ().Substring(1) + "\n";
					}
					else {
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
<<<<<<< HEAD
			/*string title = null;
=======
			string title = findValuebyKey("title");

			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			if (!Directory.Exists(documents + "/SavedWorkouts")) {
				var directoryname = Path.Combine (documents, "SavedWorkouts");
				Directory.CreateDirectory(directoryname);
			}

			client.DownloadFile(pageURL, documents + "/SavedWorkouts/" + title + ".txt");
		}

		private string findValuebyKey(string key) {
			string value = null;
>>>>>>> master
			foreach(Tuple<string, string> page in pageDetails) {
				if (page.Item1.ToString() == key) {
					value = page.Item2.ToString();
					break;
				}
<<<<<<< HEAD
			}*/

			// DOESN'T WORK
			//client.DownloadFile(pageURL, @"SavedWorkouts\test.txt");
			client.DownloadStringCompleted += (s, e) => {
				var text = e.Result; // get the downloaded text
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string localFilename = String.Format("\"{0}\"", pageURL);
				string localPath = Path.Combine (documentsPath, localFilename);
				File.WriteAllText (localPath, text); // writes to local storage
			};
			var url = new Uri(pageURL);
			client.Encoding = Encoding.UTF8;
			client.DownloadStringAsync(url);
=======
			}
			return value;
>>>>>>> master
		}
	}
}
