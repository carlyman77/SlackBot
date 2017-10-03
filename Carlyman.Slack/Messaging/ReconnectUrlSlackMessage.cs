#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class ReconnectUrlSlackMessage : SlackMessage
    {
        [DataMember(Name = "type")]
        public string MessageType
        {
            get;
            set;
        }

        [DataMember(Name = "url")]
        public string Url
        {
            get;
            set;
        }
    }
}
