#region Using References

using System;

#endregion

namespace Carlyman.Slack.Messaging
{
    internal class SlackStartRequest : SlackRequest
    {
        public SlackStartRequest(string Token)
        {
            _token = Token;
        }

        private readonly string _token;

        protected override SlackRtmStartResponse Get<SlackRtmStartResponse>(string uri)
        {
            return base.Get<SlackRtmStartResponse>(uri);
        }

        public Start Start()
        {
            return Get<Start>($"{SlackApiRoot}rtm.start?token={_token}");
        }
    }
}
