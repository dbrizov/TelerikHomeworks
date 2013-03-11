using System;

class ReplaceTags
{
    static void Main(string[] args)
    {
        string html = @"<p>
    Please visit
    <a href=""http://academy.telerik.com""> our site</a>
    to choose a training course. Also visit
    <a href=""www.devbg.org""> our forum</a>
    to discuss the courses.
</p>";
        Console.WriteLine(html);

        int index = html.IndexOf("<a");

        while (index != -1)
        {
            int firstQuotesIndex = html.IndexOf('\"', index + 1);
            int secondQuotesIndex = html.IndexOf('\"', firstQuotesIndex + 1);

            string substring = html.Substring(firstQuotesIndex + 1, secondQuotesIndex - firstQuotesIndex - 1);
            html = html.Replace(string.Format(@"<a href=""{0}"">", substring), 
                string.Format("[URL={0}]", substring));

            index = html.IndexOf("<a", secondQuotesIndex);
        }

        html = html.Replace("</a>", "[/URL]");

        Console.WriteLine(html);
    }
}