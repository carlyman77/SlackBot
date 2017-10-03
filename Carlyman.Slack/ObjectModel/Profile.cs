#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.ObjectModel
{
    [DataContract]
    public class Profile
    {
        [DataMember(Name = "avatar_hash")]
        public string AvatarHash
        {
            get;
            set;
        }

        [DataMember(Name = "display_name")]
        public string DisplayName
        {
            get;
            set;
        }

        [DataMember(Name = "display_name_normalized")]
        public string DisplayNameNormalised
        {
            get;
            set;
        }

        [DataMember(Name = "email")]
        public string Email
        {
            get;
            set;
        }

        [DataMember(Name = "first_name")]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember(Name = "last_name")]
        public string LastName
        {
            get;
            set;
        }

        [DataMember(Name = "real_name")]
        public string RealName
        {
            get;
            set;
        }

        [DataMember(Name = "real_name_normalized")]
        public string RealNameNormalised
        {
            get;
            set;
        }

        [DataMember(Name = "status_emoji")]
        public string StatusEmoji
        {
            get;
            set;
        }

        [DataMember(Name = "status_text")]
        public string StatusText
        {
            get;
            set;
        }

        [DataMember(Name = "team")]
        public string TeamID
        {
            get;
            set;
        }
        [DataMember(Name = "title")]
        public string Title
        {
            get;
            set;
        }
    }
}
