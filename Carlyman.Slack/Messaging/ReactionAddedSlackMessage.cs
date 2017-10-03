#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class ReactionAddedSlackMessage : SlackMessage
    {
        [DataMember(Name = "channel")]
        public string Channel
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