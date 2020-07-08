using System.Text;

namespace SearchWordBox
{
    public static class HelpExtension
    {
       public static string GetProcessString(this string source)
       {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in source)
            {
                if((c<='Z'&&c>='A')||(c<='z'&&c>='a')||char.IsDigit(c))
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
       }
    }
}
