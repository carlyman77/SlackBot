#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Carlyman.Slack.ObjectModel
{
    [DataContract]
    public class Self
    {
        [DataMember(Name = "id")]
        public string ID
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
    }
}