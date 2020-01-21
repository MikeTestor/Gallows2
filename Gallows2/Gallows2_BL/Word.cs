using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows2_BL
{
    public class Word
    {
        public string TheWord { get; set; }

        private Dictionary<int, Letter> letters;
        public Word(string word)
        {
            TheWord = word;
            CreateDicLetters();
        }

        private void CreateDicLetters()
        {
            letters = new Dictionary<int, Letter>();
            int a = 0;
            foreach(char c in TheWord)
            {
                Letter letter = new Letter(c);
                letters.Add(a, letter);
                a++;
            }
        }

        public List<int> GetPosLettersInWord(char letter)
        {
            List<int> positions = new List<int>();
            var lettersInWord = letters.Where(let => let.Value.TheLetter == letter);
            foreach(var kvp in lettersInWord)
            {
                positions.Add(kvp.Key);
            }

            return positions;
        }

        public bool SetLettersToGuessed(List<int> positions)
        {
            foreach(int pos in positions)
            {
                letters[pos].Guessed = true;
            }
            foreach (var l in letters)
            {
                if (l.Value.Guessed == false)
                    return false;
            }
            return true;
        }

        class Letter
        {
            public char TheLetter { get; set; }
            public bool Guessed { get; set; }

            public Letter(char letter)
            {
                TheLetter = letter;
                Guessed = false;
            }
        }        
    }
}
