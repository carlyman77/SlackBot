#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class BotResponderSlackResponse : SlackResponse
    {
        public BotResponderSlackResponse()
        {
			_messageType = "message";
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
        }

        [DataMember(Name = "text")]
        public string Text
        {
            get;
            set;
        }
    }
}