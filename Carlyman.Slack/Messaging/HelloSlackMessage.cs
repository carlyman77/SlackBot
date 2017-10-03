#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class HelloSlackMessage : SlackMessage
    {
        [DataMember(Name = "type")]
        public string MessageType
        {
            get;
            set;
        }
    }
}
