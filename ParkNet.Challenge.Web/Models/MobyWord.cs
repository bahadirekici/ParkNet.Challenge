using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkNet.Challenge.Web.Models
{
    public class MobyWord
    {
        public MobyWord()
        {

        }
        public MobyWord(string word,int count)
        {
            Word = word;
            Count = count;
        }
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
