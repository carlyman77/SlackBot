#region Using References

using System;
using System.Configuration;

#endregion

namespace Carlyman.Slack
{
	public static class ApplicationConfiguration
    {
        internal const string SlackBotApiTokenKey = "SlackBotApiToken";

        public static string SlackBotApiToken
        {
            get
            {
                return GetAppSettingsValue(SlackBotApiTokenKey);
            }
        }

        private static string GetAppSettingsValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}