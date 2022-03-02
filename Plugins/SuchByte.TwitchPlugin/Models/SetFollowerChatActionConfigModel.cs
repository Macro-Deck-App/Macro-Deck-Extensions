using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SuchByte.TwitchPlugin.Models
{
    public class SetFollowerChatActionConfigModel : ISerializableConfiguration
    {
        public SetFollowerChatActionMethod Method { get; set; } = SetFollowerChatActionMethod.On;
        public double RequiredFollowTime { get; set; } = TimeSpan.FromMinutes(10).TotalSeconds;

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static SetFollowerChatActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<SetFollowerChatActionConfigModel>(config);
        }
    }

    public enum SetFollowerChatActionMethod
    {
        On,
        Off,
        Toggle
    }
}
