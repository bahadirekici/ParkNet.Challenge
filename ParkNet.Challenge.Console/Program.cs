using System;

namespace ParkNet.Challenge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Downloading story..");
            var mobi = new MobyDick();
            mobi.DownloadCompleted += (story, status) =>
            {
                System.Console.WriteLine("Download complete..");
                System.Console.WriteLine("Counting words..");
                var stats = mobi.CountWords(story);
                System.Console.WriteLine("Counting complete..");

                System.Console.WriteLine("Saving XML file..");
                var mobiXML = new MobyDickXML();
                var doc = mobiXML.CreateDocument(stats);
                var path = AppDomain.CurrentDomain.BaseDirectory + "mobydick.xml";
                mobiXML.SaveDocument(doc, path);
                System.Console.WriteLine("File saved.. [" + path + "]");


            };
            mobi.DownloadStoryAsync("http://www.gutenberg.org/files/2701/2701-0.txt");
            System.Console.ReadLine();
        }
    }
}
