#region Using References

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

#endregion

namespace Carlyman.Slack.Messaging
{
    public class SlackRequest
    {
        internal const string SlackApiRoot = "https://slack.com/api/";

        protected string Get(string uri)
        {
            string get = "";

            if (String.IsNullOrEmpty(uri) == false)
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)(HttpWebRequest.Create(uri));

                try
                {
                    using (HttpWebResponse httpWebResponse = (HttpWebResponse)(httpWebRequest.GetResponse()))
                    {
                        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            get = streamReader.ReadToEnd();
                        }
                    }
                }
                catch (WebException webException)
                {
                    Console.WriteLine(webException.Message);
                }
            }

            return get;
        }

        protected virtual T Get<T>(string uri)
        {
            string response = Get(uri);

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
