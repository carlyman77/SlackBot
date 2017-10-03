#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class TypingSlackResponse : SlackResponse
    {
        public TypingSlackResponse()
        {
			_messageType = "typing";
        }

		private string _messageType;

        [DataMember(Name = "channel")]
        public string Channel
        {
            get;
            set;
        }

        [DataMember(Name = "id")]
        public long ID
        {
            get;
            set;
        }

        [DataMember(Name = "type")]
        public string MessageType
        {
            get
			{
				return _messageType;
			}
            set
			{
				_messageType = value;
			}
        }
    }
}