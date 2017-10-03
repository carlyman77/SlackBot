#region Using References

using System;

using Carlyman.Slack.Messaging;

#endregion

namespace Carlyman.Slack.TestConsoleApp.MessageHandlers
{
	internal class HealthCheckMessageHandler : MessageHandler
    {
        public override SlackMessageResponse GetResponse(SlackMessageContext slackMessageContext)
        {
            return new SlackMessageResponse($"Yes thank you {slackMessageContext.User.Username}, I am fine.");
        }

        public override bool IsHandle(SlackMessageContext SlackMessageContext)
        {
            bool isRespond = base.IsHandle(SlackMessageContext);

            string message = SlackMessageContext.Text.SkipFirstWord();
            if (message.ToLower().StartsWith("are you ok") == true)
            {
                isRespond = true;
            }

            return isRespond;
        }
    }
}