#region Using References

using System;

using Carlyman.Slack.Messaging;

#endregion

namespace Carlyman.Slack.TestConsoleApp.MessageHandlers
{
	internal class HelloMessageHandler : MessageHandler
    {
        public override SlackMessageResponse GetResponse(SlackMessageContext slackMessageContext)
        {
            return new SlackMessageResponse($"Hello to you, {slackMessageContext.User.Username}.");
        }

        public override bool IsHandle(SlackMessageContext slackMessageContext)
        {
            bool isRespond = base.IsHandle(slackMessageContext);

            string message = slackMessageContext.Text.SkipFirstWord();
            if (message.ToLower().StartsWith("hello") == true)
            {
                isRespond = true;
            }

            return isRespond;
        }
    }
}