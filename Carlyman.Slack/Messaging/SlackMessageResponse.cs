#region Using References

using System;

#endregion

namespace Carlyman.Slack.Messaging
{
    public class SlackMessageResponse
    {
        public SlackMessageResponse(string text)
        {
            _text = text;
        }

        private readonly string _text;

        public string Text
        {
            get
            {
                return _text;
            }
        }
    }
}
