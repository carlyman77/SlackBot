#region Using References

using System;

using Carlyman.Slack.TestConsoleApp.MessageHandlers;

#endregion

namespace Carlyman.Slack.TestConsoleApp
{
    public class Program
    {
		public static void Main(string[] args)
        {
			MessageHandler[] messageHandlers = new MessageHandler[]
			{
				new HealthCheckMessageHandler(),
				new HelloMessageHandler(),
				new PingMessageHandler()
			};

			using (SlackBot slackBot = new SlackBot(ApplicationConfiguration.SlackBotApiToken, messageHandlers))
			{
				slackBot.Start();

				while (Console.ReadLine() != "Close")
				{
				}
			}

			Console.WriteLine("Boo!");
        }
    }
}
