#region Using References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Carlyman.Slack.Messaging;
using Carlyman.Slack.ObjectModel;

#endregion

namespace Carlyman.Slack
{
    public class SlackBot : IDisposable
    {
        public SlackBot(string token)
        {
            _token = token;
        }

        public SlackBot(string token, IEnumerable<MessageHandler> messageHandlers)
            : this(token)
        {
            _messageHandlers = messageHandlers.ToList();
        }

		private List<Channel> _channels;
        private ClientWebSocket _clientWebSocket;
        private string _id;
		private readonly List<MessageHandler> _messageHandlers;
		private string _name;
        private readonly string _token;
        private List<User> _users;

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public async void Dispose()
        {
            if (_clientWebSocket != null)
            {
                if (_clientWebSocket.State != WebSocketState.Closed)
                {
                    await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                }

                _clientWebSocket.Dispose();
            }
        }

        protected async virtual void OnMessageReceived(MessageSlackMessage messageSlackMessage)
        {
            if (messageSlackMessage != null)
            {
                WriteLineToConsole($"Message received");

                string text = messageSlackMessage.Text;

                if ((String.IsNullOrEmpty(text) == false) && ((text.StartsWith($"@{_name}") == true) || (text.StartsWith($"<@{_id}>") == true)))
                {
                    string channelID = messageSlackMessage.ChannelID;
                    User user = _users.Where(m => (m.ID == messageSlackMessage.UserID)).FirstOrDefault();
                    SlackMessageContext slackMessageContext = new SlackMessageContext(channelID, user, text);

                    WriteLineToConsole($"Message for {_name} from {user.Name}");

                    foreach (MessageHandler messageHandler in _messageHandlers.Where(m => (m.IsHandle(slackMessageContext) == true)))
                    {
                        SlackMessageResponse oSlackMessageResponse = messageHandler.GetResponse(slackMessageContext);

                        await SendTypingResponse(slackMessageContext);
                        await Send(slackMessageContext, oSlackMessageResponse);
                    }
                }
            }
        }

        private async Task Receive()
        {
            while (_clientWebSocket.State == WebSocketState.Open)
            {
                byte[] buffer = new byte[1024];
                WebSocketReceiveResult webSocketReceiveResult = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                }
                else
                {
                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    string messageType = "";

                    if (message.Contains("\"type\":\"") == true)
                    {
                        messageType = message.Substring(message.IndexOf("\"type\":\"") + "\"type\":\"".Length);

                        if (messageType.Contains("\"") == true)
                        {
                            messageType = messageType.Substring(0, messageType.IndexOf("\""));
                        }
                    }

                    if (String.IsNullOrWhiteSpace(messageType) == false)
                    {
                        SlackMessage slackMessage = null;

                        switch (messageType.ToLower())
                        {
                            case "desktop_notification":
                                slackMessage = Serialiser.FromString<DesktopNotificationSlackMessage>(message);
                                break;

                            case "hello":
                                slackMessage = Serialiser.FromString<HelloSlackMessage>(message);
                                break;

                            case "message":
                                MessageSlackMessage oMessageSlackMessage = Serialiser.FromString<MessageSlackMessage>(message);

                                OnMessageReceived(oMessageSlackMessage);

                                slackMessage = oMessageSlackMessage;
                                break;

                            case "presence_change":
                                slackMessage = Serialiser.FromString<PresenceChangeSlackMessage>(message);
                                break;

                            case "reconnect_url":
                                slackMessage = Serialiser.FromString<ReconnectUrlSlackMessage>(message);
                                break;

                            case "user_typing":
                                slackMessage = Serialiser.FromString<UserTypingSlackMessage>(message);
                                break;

                            default:
                                WriteLineToConsole($"Unhandled message type: {messageType}");
                                break;
                        }
                    }
                }
            }
        }

        private async Task Send(SlackMessageContext slackMessageContext, SlackMessageResponse slackMessageResponse)
        {
            BotResponderSlackResponse oBotResponderSlackResponse = new BotResponderSlackResponse()
            {
                Channel = slackMessageContext.ChannelID,
                ID = DateTime.Now.Ticks,
                Text = slackMessageResponse.Text
            };

            await Send(oBotResponderSlackResponse);
        }

        private async Task Send(SlackResponse slackResponse)
        {
            WriteLineToConsole($"Sending message");

            string json = Serialiser.ToJsonString<SlackResponse>(slackResponse);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task SendTypingResponse(SlackMessageContext slackMessageContext)
        {
            TypingSlackResponse typingSlackResponse = new TypingSlackResponse()
            {
                Channel = slackMessageContext.ChannelID,
                ID = DateTime.Now.Ticks
            };
        
            await Send(typingSlackResponse);
        }

        public async void Start()
        {
            WriteLineToConsole();
            WriteLineToConsole("Starting bot...");

            SlackStartRequest slackRtmStartRequest = new SlackStartRequest(_token);
            Start start = slackRtmStartRequest.Start();

            if ((start != null) && (String.IsNullOrEmpty(start.Url) == false))
            {
                _id = start.Self.ID;
                _name = start.Self.Name;
                _channels = start.Channels.ToList();
                _users = start.Users.ToList();

                WriteLineToConsole($"Bot started - {_name} ({_id}): {_channels.Count} channels, {_users.Count} users");
                WriteLineToConsole("Establishing connection...");

                _clientWebSocket = new ClientWebSocket();

                await _clientWebSocket.ConnectAsync(new Uri(start.Url), CancellationToken.None);

                WriteLineToConsole("Connected");

                await Receive();
            }
        }

        private static void WriteLineToConsole()
        {
            Console.WriteLine();
        }

        private static void WriteLineToConsole(string value)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd-MMM-yyyy @ HH:mm")} {value}");
        }
    }
}
