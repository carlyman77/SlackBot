#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class MessageSlackMessage : SlackMessage
    {
        [DataMember(Name = "channel")]
        public string ChannelID
        {
            get;
            set;
        }

        [DataMember(Name = "source_team")]
        public string SourceTeam
        {
            get;
            set;
        }

        [DataMember(Name = "team")]
        public string Team
        {
            get;
            set;
        }

        [DataMember(Name = "text")]
        public string Text
        {
            get;
            set;
        }

        [DataMember(Name = "ts")]
        public string Timestamp
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
        public string UserID
        {
            get;
            set;
        }
    }
}