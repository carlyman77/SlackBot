#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.ObjectModel
{
    [DataContract]
    public class Channel
    {
        private string _name;

        [DataMember(Name = "id")]
        public string ID
        {
            get;
            set;
        }

        [DataMember(Name = "is_archived")]
        public bool IsArchived
        {
            get;
            set;
        }

        [DataMember(Name = "is_channel")]
        public bool IsChannel
        {
            get;
            set;
        }

        [DataMember(Name = "is_general")]
        public bool IsGeneral
        {
            get;
            set;
        }

        [DataMember(Name = "is_member")]
        public bool IsMember
        {
            get;
            set;
        }

        [DataMember(Name = "name")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;

                if (String.IsNullOrEmpty(_name) == false)
                {
                    _name = $"#{_name}";
                }
            }
        }
    }
}