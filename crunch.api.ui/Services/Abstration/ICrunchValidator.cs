namespace crunch.api.ui.Services.Abstration
{
    public interface ICrunchValidator
    {
        public bool IsAllCapitalLetters(String str);
        public bool IsAllValidPunctuations(String str);

        public bool IsBetween2and70Characters(String str);
    }
}
