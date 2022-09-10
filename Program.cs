using System.Text.RegularExpressions;

namespace StringTools
{
    class Program
    {
        public static void Main(string[] args)
        {
            var text = ReadText();
            text = ReplaceFirstPriToPre(text);
            text = ReplaceLastIiToIe(text);
            WriteText(text);
        }

        public static string ReadText()
        {
            return Console.ReadLine();
        }

        public static string ReplaceFirstPriToPre(string text)
        {
            var pattern = @"\b[П,п][Р,р][И,и]";
            var regex = new Regex(pattern);
            var match = regex.Match(text);
            if (!match.Success)
                return text;
            var replacement = "пре";
            if (match.Value[0] == 'П')
                replacement = replacement.Replace('п', 'П');
            if (match.Value[1] == 'Р')
                replacement = replacement.Replace('р', 'Р');
            if (match.Value[2] == 'И')
                replacement = replacement.Replace('е', 'Е');
            return regex.Replace(text, replacement, 1);
        }

        public static string ReplaceLastIiToIe(string text)
        {
            var pattern = @"[И,и]{2}\b";
            var regex = new Regex(pattern);
            var match = regex.Matches(text).LastOrDefault();
            if (match == null || !match.Success)
                return text;

            var replacement = "ие";
            if (match.Value[0] == 'И')
                replacement = replacement.Replace('и', 'И');
            if (match.Value[1] == 'И')
                replacement = replacement.Replace('е', 'Е');
            return regex.Replace(text, replacement, 1, match.Index);
        }

        public static void WriteText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
