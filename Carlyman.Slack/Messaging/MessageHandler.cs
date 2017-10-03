#region Using References

using System;

using Carlyman.Slack.Messaging;

#endregion

namespace Carlyman.Slack
{
    public class MessageHandler
    {
        public virtual bool IsHandle(SlackMessageContext slackMessageContext)
        {
            return false;
        }

        public virtual SlackMessageResponse GetResponse(SlackMessageContext slackMessageContext)
        {
            return null;
        }
    }
}
