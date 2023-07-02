namespace crunch.api.ui.Services.Abstration
{
    public interface IStringCruncher
    {

        public String CrunchVowls(String str);

        public String CrunchRepeatedCharachers(String str);

        public String CrunchBeginningAndEndBlanks(String str);

        public String CrunchConsecutiveBlanks(String str);

        public String CrunchBlanksBeforePunctuations(String str);


    }
}
