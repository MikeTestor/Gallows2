using System;
using System.Collections.Generic;
using System.IO;

namespace Gallows2_BL
{
    public static class Loader
    {        
        public static List<string> LoadWords()
        {               
            string fileName = @"C:\C#\C# projecten\Games\Gallows2\words.txt";
            FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);

            List<string> Words = new List<string>();
            var inputRecord = fileReader.ReadLine();
            while (inputRecord != null)
            {                
                Words.Add(inputRecord);
                inputRecord = fileReader.ReadLine();
            } 
            return Words;
        }
    }
}
