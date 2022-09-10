using System.Text;

namespace Lacinizatar.Logic
{
    public class ToBelLatin
    {
        private char _previousLetter;
        private char _currentLetter;
        private char _nextLetter;
        private string _cyrillic;
        private IEnumerator<char> _enumerator;

        public ToBelLatin(string cyrillicText)
        {
            _cyrillic = cyrillicText;
            _enumerator = _cyrillic.GetEnumerator();
        }

        /// <summary>
        /// Translate Cyrillic sentence to Latin.
        /// </summary>
        /// <param name="cyrillic">Validated sentence only with belarussian letters, whitespaces and punctuation marks.</param>
        /// <returns>Letin sentence.</returns>
        public string Translate()
        {
            StringBuilder result = new StringBuilder();
            if (_cyrillic.Length == 1)
            {
                return TranslateOneLetter();
            }

            MoveToFirstLetter();
            result.Append(TranslateOneLetter());
            while(MoveToNextLetter())
            {
                result.Append(TranslateOneLetter());
            }

            result.Append(TranslateOneLetter());

            return result.ToString();
        }

        internal string TranslateOneLetter()
        {
            return _currentLetter switch
            {
                'а' => "a",
                'б' => "b",
                'в' => "v",
                'г' => "h",
                'д' => "d",
                'е' => !char.IsLetter(_previousLetter) || new char[] { 'а', 'е', 'ё', 'і', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ь', 'й' }.Contains(_previousLetter) ?
                "je" :
                (_previousLetter == 'л' ? "e" : "ie"),
                'ё' => !char.IsLetter(_previousLetter) || new char[] { 'а', 'е', 'ё', 'і', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ь', 'й' }.Contains(_previousLetter) ?
                "jo" :
                (_previousLetter == 'л' ? "o" : "io"),
                'ж' => "ž",
                'з' => _nextLetter == 'ь' ? "ź" : "z",
                'і' => "i",
                'й' => new char[] { 'а', 'е', 'ё', 'і', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ь' }.Contains(_nextLetter) ?
                "" :
                "j",
                'к' => "k",
                'л' => new char[] { 'е', 'ё', 'ю', 'я', 'ь' }.Contains(_nextLetter) ? "l" : "ł",
                'м' => "m",
                'н' => _nextLetter == 'ь' ? "ń" : "n",
                'о' => "o",
                'п' => "p",
                'р' => "r",
                'с' => _nextLetter == 'ь' ? "ś" : "s",
                'т' => "t",
                'у' => "u",
                'ў' => "ŭ",
                'ф' => "f",
                'х' => "ch",
                'ц' => _nextLetter == 'ь' ? "ć" : "c",
                'ч' => "č",
                'ш' => "š",
                'ы' => "y",
                'э' => "e",
                'ю' => !char.IsLetter(_previousLetter) || new char[] { 'а', 'е', 'ё', 'і', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ь' }.Contains(_previousLetter) ?
                "ju" :
                (_previousLetter == 'л' ? "u" : "iu"),
                'я' => !char.IsLetter(_previousLetter) || new char[] { 'а', 'е', 'ё', 'і', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ь' }.Contains(_previousLetter) ?
                "ja" :
                (_previousLetter == 'л' ? "a" : "ia"),
                '\'' => "j",
                'ь' => "",
                _ => throw new ArgumentException(nameof(_currentLetter))
            };
        }

        private void MoveToFirstLetter()
        {
            _enumerator = _cyrillic.GetEnumerator();
            _enumerator.MoveNext();
            _currentLetter = _enumerator.Current;
            _enumerator.MoveNext();
            _nextLetter = _enumerator.Current;
        }

        private bool MoveToNextLetter()
        {
            bool notFinished = _enumerator.MoveNext();
            _previousLetter = _currentLetter;
            _currentLetter = _nextLetter;
            _nextLetter = notFinished ? _enumerator.Current : '\0';
            return notFinished;
        }
    }
}