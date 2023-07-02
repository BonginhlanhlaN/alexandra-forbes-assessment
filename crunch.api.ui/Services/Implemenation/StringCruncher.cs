using crunch.api.ui.Services.Abstration;
using System.Linq;

namespace crunch.api.ui.Services.Implemenation
{
    public class StringCruncher : IStringCruncher
    {

        /**
         * This Class Takes Care Of Cruching the String 
         * i.e Changing the Original String to the Crunched Version
         */

        public StringCruncher() { }

        public String CrunchVowls(string str)
        {

            /**
             * Removes All Vowls on the String and Returns a Vowelless String.
             */

            String stringWithouVowls = "";

            var vowls = new List<char>()
            {
                'A',
                'E',
                'I',
                'O',
                'U'
                
            };


            foreach(char character in str)
            {

                if (!vowls.Contains(character))
                {

                    stringWithouVowls += character;

                }

            }

            return stringWithouVowls;
        }


        public String CrunchRepeatedCharachers(string str)
        {

            /**
            * Removes Characters That Occure More Than Once, lives only one.
            */

            String stringWithoutRepeatedCharacters = "";

            var nonRepeatedCharacters = new List<char>();

            foreach (char character in str)
            {

                if (character.Equals(' '))
                {
                    stringWithoutRepeatedCharacters += character;
                    continue;
                }
           
                if (!nonRepeatedCharacters.Contains(character))
                {

                    nonRepeatedCharacters.Add(character);
                    stringWithoutRepeatedCharacters += character;

                }
                
            }

            return stringWithoutRepeatedCharacters;

        }

        public String CrunchBeginningAndEndBlanks(String str)
        {
            /**
            * Removes Blanks at End Of String.
            */

            String trimmedString = str.Trim();

            return trimmedString;

        }

        public String CrunchConsecutiveBlanks(string str)
        {

            /**
           * Removes Blanks that occure in a Row.
           */

            String stringWithoutRepeatingSpaces = "";

            var currentIndex = 0;

            foreach (char character in str)
            {
                
                if (character.Equals(' '))
                {
                    char nextCharUponBlank = str[currentIndex + 1];

                    if (!nextCharUponBlank.Equals(' '))
                    {
                        stringWithoutRepeatingSpaces += character;
                    }

                   

                }
                else
                {
                    stringWithoutRepeatingSpaces += character;
                }
               
                currentIndex++;

            }

            return stringWithoutRepeatingSpaces;

        }

        public string CrunchBlanksBeforePunctuations(string str)
        {

            /**
            * Removes Blanks that occure Before Permited Punctuations.
            */

            String stringWithoutBlanksBeforePunctuation = "";

            var punctuations = new List<char>()
            {

                '.',
                ',',
                '?'

            };

            var currentIndex = 0;

            foreach (char character in str)
            {

                if (character.Equals(' '))
                {
                    char nextCharUponBlank = str[currentIndex + 1];

                    if (!punctuations.Contains(nextCharUponBlank))
                    {
                        stringWithoutBlanksBeforePunctuation += character;
                    }

                }
                else
                {
                    stringWithoutBlanksBeforePunctuation += character;
                }

                currentIndex++;

            }

            return stringWithoutBlanksBeforePunctuation;

        }

    }

}
