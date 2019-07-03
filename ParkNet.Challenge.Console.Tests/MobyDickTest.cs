using NUnit.Framework;
using ParkNet.Challenge.Console;
using System.Linq;

namespace Tests
{
    public class MobyDickTest
    {
        [Test]
        public void DownloadStoryAsync_Test()
        {
            var mobi = new MobyDick();
            mobi.DownloadCompleted += (story, status) =>
            {
                if (string.IsNullOrEmpty(story))
                    Assert.Fail("Story is null or empty - " + status);
            };
            mobi.DownloadStoryAsync("http://www.gutenberg.org/files/2701/2701-0.txt");
        }


        [Test]
        public void CountWords_Test()
        {
            var mobi = new MobyDick();
            mobi.DownloadCompleted += (story, status) =>
            {
                if (string.IsNullOrEmpty(story))
                {
                    Assert.Fail("Story is null or empty - " + status);
                }
                else
                {
                    var stats = mobi.CountWords(story);
                    Assert.IsNotNull(stats, "Stats is null");
                }
            };
            mobi.DownloadStoryAsync("http://www.gutenberg.org/files/2701/2701-0.txt");
        }



        [Test]
        public void CreateDocument_Test()
        {
            var mobi = new MobyDick();
            mobi.DownloadCompleted += (story, status) =>
            {
                if (string.IsNullOrEmpty(story))
                {
                    Assert.Fail("Story is null or empty - " + status);
                }
                else
                {
                    var stats = mobi.CountWords(story);
                    Assert.IsNotNull(stats, "Stats is null");

                    var mobiXML = new MobyDickXML();
                    var doc = mobiXML.CreateDocument(stats);

                    var wordElementCount = doc.Element("words").Elements().Count();
                    Assert.Greater(wordElementCount, 1, "word count must greater than one");
                }
            };
            mobi.DownloadStoryAsync("http://www.gutenberg.org/files/2701/2701-0.txt");
        }
    }
}