#region Using References

using System;
using System.Linq;

#endregion

namespace Carlyman.Slack.TestConsoleApp
{
	public static class StringExtensions
    {
		internal const string NonBreakingSpace = "&nbsp;";

        public static string ReplaceNonBreakingSpace(this string value, int defaultValue)
        {
            string replaceNonBreakingSpace = value;

            if (String.IsNullOrEmpty(replaceNonBreakingSpace) == false)
            {
                replaceNonBreakingSpace = replaceNonBreakingSpace.Replace("&nbsp;", defaultValue.ToString());
            }

            return replaceNonBreakingSpace;
        }

        public static string SkipFirstWord(this string value)
        {
            string skipFirstWord = value;

            if (String.IsNullOrEmpty(skipFirstWord) == false)
            {
                skipFirstWord = skipFirstWord.Substring(skipFirstWord.IndexOf(" ") + 1).Trim();
            }

            return skipFirstWord;
        }
    }
}
