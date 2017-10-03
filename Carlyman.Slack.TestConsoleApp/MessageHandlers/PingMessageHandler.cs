#region Using References

using System;

using Carlyman.Slack.Messaging;

#endregion

namespace Carlyman.Slack.TestConsoleApp.MessageHandlers
{
    internal class PingMessageHandler : MessageHandler
    {
		public override SlackMessageResponse GetResponse(SlackMessageContext slackMessageContext)
		{
			return new SlackMessageResponse("Pong!");
		}

		public override bool IsHandle(SlackMessageContext slackMessageContext)
		{
			bool isRespond = base.IsHandle(slackMessageContext);

			string message = slackMessageContext.Text.SkipFirstWord();
			if (message.ToLower() == "ping")
			{
				isRespond = true;
			}

			return isRespond;
		}
	}
}
