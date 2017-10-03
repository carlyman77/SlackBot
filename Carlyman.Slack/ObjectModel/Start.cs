#region Using References

using System;
using System.Runtime.Serialization;

using Carlyman.Slack.ObjectModel;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    internal class Start
    {
        [DataMember(Name = "channels")]
        public Channel[] Channels
        {
            get;
            set;
        }

        [DataMember(Name = "ims")]
        public InstantMessage[] InstantMessages
        {
            get;
            set;
        }

        [DataMember(Name = "self")]
        public Self Self
        {
            get;
            set;
        }

        [DataMember(Name = "team")]
        public Team Team
        {
            get;
            set;
        }

        [DataMember(Name = "url")]
        public string Url
        {
            get;
            set;
        }

        [DataMember(Name = "users")]
        public User[] Users
        {
            get;
            set;
        }
    }
}
