#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.Messaging
{
    [DataContract]
    public class DesktopNotificationSlackMessage : SlackMessage
    {
        [DataMember(Name = "avatarImage")]
        public string AvatarImage
        {
            get;
            set;
        }

        [DataMember(Name = "channel")]
        public string Channel
        {
            get;
            set;
        }

        [DataMember(Name = "content")]
        public string Content
        {
            get;
            set;
        }

        [DataMember(Name = "title")]
        public string Company
        {
            get;
            set;
        }

        [DataMember(Name = "event_ts")]
        public string EventTimestamp
        {
            get;
            set;
        }

        [DataMember(Name = "imageUri")]
        public string ImageUri
        {
            get;
            set;
        }

        [DataMember(Name = "is_shared")]
        public bool IsShared
        {
            get;
            set;
        }

        [DataMember(Name = "launchUri")]
        public string LaunchUri
        {
            get;
            set;
        }

        [DataMember(Name = "msg")]
        public string MessageValue
        {
            get;
            set;
        }

        [DataMember(Name = "ssbFilename")]
        public string SsbFilename
        {
            get;
            set;
        }

        [DataMember(Name = "type")]
        public string MessageType
        {
            get;
            set;
        }

        [DataMember(Name = "subtitle")]
        public string Username
        {
            get;
            set;
        }
    }
}