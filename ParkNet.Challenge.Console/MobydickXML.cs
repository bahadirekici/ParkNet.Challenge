using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ParkNet.Challenge.Console
{
    public class MobyDickXML
    {
        public XDocument CreateDocument(Dictionary<string,int> stats)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("words");
            foreach (var item in stats)
            {
                XElement word = new XElement("word");
                word.Add(new XAttribute("text",item.Key));
                word.Add(new XAttribute("count", item.Value));
                root.Add(word);
            }
            doc.Add(root);
            return doc;
        }
        public void SaveDocument(XDocument doc,string path)
        {
            try
            {
                doc.Save(path);
            }
            catch (Exception x)
            {
                throw x;
            }
            
        }
    }
}
