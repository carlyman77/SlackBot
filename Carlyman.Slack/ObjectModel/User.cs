#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.ObjectModel
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "is_admin")]
        public bool IsAdmin
        {
            get;
            set;
        }

        [DataMember(Name = "deleted")]
        public bool IsDeleted
        {
            get;
            set;
        }

        [DataMember(Name = "id")]
        public string ID
        {
            get;
            set;
        }

        [DataMember(Name = "is_app_user")]
        public bool IsAppUser
        {
            get;
            set;
        }

        [DataMember(Name = "is_bot")]
        public bool IsBot
        {
            get;
            set;
        }

        [DataMember(Name = "is_owner")]
        public bool IsOwner
        {
            get;
            set;
        }

        [DataMember(Name = "is_primary_owner")]
        public bool IsPrimaryOwner
        {
            get;
            set;
        }

        [DataMember(Name = "is_restricted")]
        public bool IsRestricted
        {
            get;
            set;
        }

        [DataMember(Name = "is_ultra_restricted")]
        public bool IsUltraRestricted
        {
            get;
            set;
        }

        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        [DataMember(Name = "presence")]
        public string Presence
        {
            get;
            set;
        }

        [DataMember(Name = "profile")]
        public Profile Profile
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

        [DataMember(Name = "team_id")]
        public string TeamID
        {
            get;
            set;
        }

        public string Username
        {
            get
            {
                return $"<@{ID}>";
            }
        }
    }
}