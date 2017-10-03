#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.ObjectModel
{
    [DataContract]
    public class InstantMessage
    {
        [DataMember(Name = "id")]
        public string ID
        {
            get;
            set;
        }

        [DataMember(Name = "is_im")]
        public bool IsInstantMessage
        {
            get;
            set;
        }

        [DataMember(Name = "is_org_shared")]
        public bool IrOrganisationShared
        {
            get;
            set;
        }

        [DataMember(Name = "is_open")]
        public bool IsOpen
        {
            get;
            set;
        }

        [DataMember(Name = "user")]
        public string Username
        {
            get;
            set;
        }
    }
}