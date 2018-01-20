using System.Globalization;

namespace Arbetsprov.Common.Text
{
    public class TextService : ITextService
    {
        private const string CultureName = "en-US";
        private readonly TextInfo _textInfo;

        public TextService()
        {
            _textInfo = GetTextInfoWithCapitilizedTitles();
        }

        public string CapitalizeFirstLetters(string text)
        {
            return _textInfo.ToTitleCase(text);
        }

        private TextInfo GetTextInfoWithCapitilizedTitles()
        {
            var americanCulture = new CultureInfo(CultureName, false);
                
            return americanCulture.TextInfo;
        }
    }
}