using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows2_BL
{
    public static class Words
    {
        public static List<string> ListOfWords { get; set; }
        private static Random rand = new Random();

        public static void GetWords()
        {
            ListOfWords = Loader.LoadWords();
        }
        public static string ChooseWord()
        {
            int n = rand.Next(ListOfWords.Count);
            return ListOfWords[n];
        }
    }
}
