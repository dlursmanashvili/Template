using Microsoft.IdentityModel.Tokens;
using Template.Model.Exceptions;

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



    public static List<string> CutText(string text)
    {
        if (text.IsNullOrEmpty())
        {
            throw new BadRequestException();
        }

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

    public static IEnumerable<string> ValidateText(List<string> CutTextList)
    {

        for (int i = 0; i < CutTextList.Count; i++)
        {
            if (CheckTtext(CutTextList[i]).Any(x => x == '<' || x == '>'))
            {
                throw new BadRequestException($"{CheckTtext(CutTextList[i])} text does not meet the standard. Please edit the text");
            }
            else
            {
                yield return CutTextList[i];
            }
        }
    }

    public static string CheckTtext(string CutTextItem)
    {
        if (CutTextItem.ToCharArray().Length > 2 && CutTextItem.ToCharArray()[0] == '<' && CutTextItem.ToCharArray().Last() == '>')
        {
            string modifiedItem = CutTextItem.Substring(1, CutTextItem.Length - 2);
            return modifiedItem;
        }
        return CutTextItem;
    }

    public static string GetCutTextSum(IEnumerable<string> strings)
    {
        var text = "";
        foreach (string s in strings)
        {
            text += s;
        }
        return text;
    }
    /// <summary>
    /// ფუნქცია დაჭრის, შეამოწმებს თუ ტექსტი ვალიდურია მაშინ დააბრუნებს გადაცემულ ტექსტს
    /// </summary>
    public static string CheckNewText(string text)
    {
        return GetCutTextSum(ValidateText(CutText(text)));
    }

  

}
