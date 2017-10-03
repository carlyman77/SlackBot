#region Using References

using System;

using Newtonsoft.Json;

#endregion

namespace Carlyman.Slack
{
    public static class Serialiser
    {
        public static T FromString<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static string ToJsonString<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
