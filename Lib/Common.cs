using System.Text.RegularExpressions;

namespace recipes.Lib
{
    public class Common<T>
    {
        public bool CheckListForNull(List<T?> list)
        {
            bool result = false;

            foreach (T? e in list)
            {
                if (e == null)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool CheckIfInputIsValid(List<string> list)
        {
            bool result = true;
            string pattern = @"^\s";

            foreach (string e in list)
            {
                Match regexcheck = Regex.Match(e, pattern);
                if (regexcheck.Success)
                {
                    result = false;
                }
            }
            return result;
        }

        public string ParseListToString(List<string> list)
        {
            string steps_parsed = string.Empty;

            foreach (string step in list)
            {
                steps_parsed = $"{steps_parsed}%__%{step}%__%";
            }

            return steps_parsed;
        }

        public List<string> ParseStringToList(string plain)
        {
            List<string> list = plain.Split("%__%").ToList();
            /*
            list.RemoveAt(list.Count - 1);
            list.RemoveAt(0);
            */
            return list;
        }
    }
}