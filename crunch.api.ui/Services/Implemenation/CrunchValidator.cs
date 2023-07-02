using crunch.api.ui.Services.Abstration;

namespace crunch.api.ui.Services.Implemenation
{
    public class CrunchValidator : ICrunchValidator
    {

        /**
         * This Class Takes Care of making sure that the String provided is a valid String.
         */
        public bool IsAllCapitalLetters(String str)
        {

            /**
             * Makes sure that the String Provided contains on Upper Case Letter.
             */

            for (int i = 0; i < str.Length; i++)
            {

                var currentCharacter = str[i];
                if (Char.IsLetter(currentCharacter) && !Char.IsUpper(currentCharacter))
                    return false;

            }

            return true;
        }

        public bool IsAllValidPunctuations(String str)
        {

            /**
             * Makes sure that the String Provided contains only permitted Punctuations. 
             */

            var punctuations = new List<char>()
            {

                '.',
                ',',
                '?'

            };

            foreach (char character in str)
            {
                var currentCharacter = character;
                if (!Char.IsLetter(currentCharacter) && !currentCharacter.Equals(' ') && !punctuations.Contains(currentCharacter))
                    return false;
            }

            return true;

        }

        public bool IsBetween2and70Characters(String str)
        {

            /**
            * Makes sure that the String Provided is with in the range of 2 and 70 characters(Assumed that this includes blanks and punctuations). 
            */

            if (str.Length >= 2 && str.Length <= 70)
                return true;

            return false;
        }

    }
}
