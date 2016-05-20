using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WorkoutAnywhere
{
    public static class WorkoutManager
    {
        private static MultiMap<string> labelMappings;			//label -> List<string> urls
        private static Dictionary<string, string> urlMappings;	//url -> title
        private static string filePath = "http://workoutanywhere.net/MobileData/mappings.txt";
		private static string basePath = "http://workoutanywhere.net/MobileData/Workouts/";
		public static void Initialize(){
			labelMappings = new MultiMap<string>();
			urlMappings = new Dictionary<string, string>();
			ReadFileFromServer();
		}
		public static string GetTitle(string url){ return urlMappings[basePath+ url];}
		private static void ParseLine(string s)
        {
            string[] words = s.Split('~');
            string url = words[0];
            string title = words[1];
            urlMappings[url] = title;
            string[] labels = words[2].Split(',');
            foreach (string l in labels)
            {
                labelMappings[l].Add(url);
            }
        }

        public static List<Tuple<string, string>> GetLabelList(List<string> labels)
        {
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();
            List<string> validURLS = new List<string>(labelMappings[labels[0]].ToArray());
            for (int i = 1; i < labels.Count; i++)
            {
                validURLS = GetCommonElements(validURLS, labelMappings[labels[i]]);
            }
            foreach (string s in validURLS)
            {
                results.Add(new Tuple<string, string>(s, urlMappings[s]));
            }
            return results;
        }

		private static List<string> GetCommonElements(List<string> l1, List<string> l2)
        {
            List<string> results = new List<string>();
            foreach (string w in l1)
            {
                if (l2.Contains(w))
                    results.Add(w);
            }
            return results;
        }

		private static void ReadFileFromServer()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(filePath);
            StreamReader reader = new StreamReader(stream);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 0)
                    ParseLine(line);
            }
        }
		public static List<Tuple<string, int>> GetLabelMenu(){
			List<Tuple<string, int>> allLabels = new List<Tuple<string, int>>();
			int temp;
			foreach (string s in labelMappings.Keys) {
				temp = labelMappings [s].Count;
				allLabels.Add(new Tuple<string, int>(s, temp));
			}
			allLabels.Sort ();
			return allLabels;
		}

    }
}

