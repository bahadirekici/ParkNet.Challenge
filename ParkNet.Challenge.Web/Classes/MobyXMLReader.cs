using ParkNet.Challenge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ParkNet.Challenge.Web.Classes
{
    public class MobyXMLReader
    {
        public List<MobyWord> Read(string path)
        {
            var list = new List<MobyWord>();
            XmlDocument doc = new XmlDocument();

            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//word");

            foreach (var node in nodes)
            {
                var element = (XmlElement)node;
                string word = element.Attributes["text"].Value;
                int count = int.Parse(element.Attributes["count"].Value);
                var mobyWord = new MobyWord(word, count);
                list.Add(mobyWord);
            }

            return list;

        }
    }
}
