namespace Template.Infrastructure.HelperClass;

public static class TextHelper
{
    public static List<string> GetChangedlist(List<string> CutTextList, Dictionary<string, string> listofCahngedWord)
    {
        var count = 0;
        for (int i = 0; i < CutTextList.Count; i++)
        {
            if (CutTextList[i].ToCharArray().Length > 2 && CutTextList[i].ToCharArray()[0] == '<' && CutTextList[i].ToCharArray().Last() == '>')
            {
                count++;
                string modifiedItem = CutTextList[i].Substring(1, CutTextList[i].Length - 2);
                Console.WriteLine(CutTextList[i] + $" {modifiedItem}");

                var result = listofCahngedWord.FirstOrDefault(x => x.Key == modifiedItem);
                if (result.Value != null)
                {
                    CutTextList[i] = result.Value;
                }
            }
        }
        Console.WriteLine(count);
        return CutTextList;
    }

    public static List<string>? CeckAndCutText(string text)
    {
        char[] punctuationMarks = { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '=', '?', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };

        var listOfWord = new List<string>();
        string word = "";
        var count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            string? filtredText = null;

            if (i == text.Length - 1)
            {
                word += text[i];
                if (word != null && punctuationMarks.Contains(word.First()))
                {
                    listOfWord.Add(word.First().ToString());
                    word = word.Substring(1);
                }
                if (word != null && punctuationMarks.Contains(word.Last()))
                {
                    filtredText = word.Last().ToString();
                    word = word.Substring(0, word.Length - 1);
                }
                if (word != null && word.Length != 0)
                {
                    listOfWord.Add(word);
                }
                if (filtredText != null)
                {
                    listOfWord.Add(filtredText);
                }
                break;
            }
            else if (text[i].ToString() != " ")
            {
                word += text[i];
            }
            else if (text[i].ToString() == " ")
            {
                if (word != null && punctuationMarks.Contains(word.First()))
                {
                    listOfWord.Add(word.First().ToString());
                    word = word.Substring(1);
                }
                if (word != null && punctuationMarks.Contains(word.Last()))
                {
                    filtredText = word.Last().ToString();
                    word = word.Substring(0, word.Length - 1);
                }
                if (word != null && word.Length != 0)
                {
                    listOfWord.Add(word);
                }
                if (filtredText != null)
                {
                    listOfWord.Add(filtredText);
                }
                listOfWord.Add(" ");
                word = null;
            }
        }
        return listOfWord;
    }
}
