#region Using References

using Carlyman.Slack.ObjectModel;
using System;

#endregion

namespace Carlyman.Slack.Messaging
{
    public class SlackMessageContext
    {
        public SlackMessageContext(string channelID, User user, string text)
        {
            _channelID = channelID;
            _text = text;
            _user = user;
        }

        private readonly string _channelID;
        private readonly string _text;
        private readonly User _user;

        public string ChannelID
        {
            get
            {
                return _channelID;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }
        }

        public User User
        {
            get
            {
                return _user;
            }
        }
    }
}
