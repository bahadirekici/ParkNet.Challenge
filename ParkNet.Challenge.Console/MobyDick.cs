using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkNet.Challenge.Console
{
    public class MobyDick
    {
        public event Action<string, string> DownloadCompleted;
        public async void DownloadStoryAsync(string downloadUrl)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(downloadUrl);
                DownloadCompleted?.Invoke(response, null);
            }
            catch (Exception x)
            {
                DownloadCompleted?.Invoke(null, x.Message);
            }
        }
        public Dictionary<string, int> CountWords(string story)
        {
            Dictionary<string, int> stats = null;
            try
            {
                stats = new Dictionary<string, int>();
                List<string> list = story.Split(' ').ToList();

                //remove any non alphabet characters
                var onlyAlphabetRegEx = new Regex(@"^[A-z]+$");
                list = list.Where(f => onlyAlphabetRegEx.IsMatch(f)).ToList();

                //further blacklist words (greater than 2 characters, not important, etc..)
                //string[] blacklist = { "a", "an", "on", "of", "or", "as", "i", "in", "is", "to", "the", "and", "for", "with", "not", "by" }; //add your own
                //list = list.Where(x => x.Length > 2).Where(x => !blacklist.Contains(x)).ToList();

                //distict keywords by key and count, and then order by count.
                var keywords = list.GroupBy(x => x).OrderByDescending(x => x.Count());

                //print each keyword to console.
                foreach (var word in keywords)
                {
                    stats.Add(word.Key, word.Count());
                }
                return stats;
            }
            catch (Exception x)
            {
                return stats;
            }
        }

    }
}
