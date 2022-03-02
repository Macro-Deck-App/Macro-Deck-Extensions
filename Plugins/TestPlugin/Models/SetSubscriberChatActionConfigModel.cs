using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SuchByte.TwitchPlugin.Models
{
    public class SetSubscriberChatActionConfigModel : ISerializableConfiguration
    {
        public SetSubscriberChatActionMethod Method { get; set; } = SetSubscriberChatActionMethod.On;

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static SetSubscriberChatActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<SetSubscriberChatActionConfigModel>(config);
        }
    }

    public enum SetSubscriberChatActionMethod
    {
        On,
        Off,
        Toggle
    }
}
