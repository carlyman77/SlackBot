#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class PresenceChangeSlackMessage : SlackMessage
    {
        [DataMember(Name = "presence")]
        public string Presence
        {
            get;
            set;
        }

        [DataMember(Name = "type")]
        public string MessageType
        {
            get;
            set;
        }

        [DataMember(Name = "user")]
        public string User
        {
            get;
            set;
        }
    }
}