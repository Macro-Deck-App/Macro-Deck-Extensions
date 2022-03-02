using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SuchByte.TwitchPlugin.Models
{
    public class SetSlowChatActionConfigModel : ISerializableConfiguration
    {
        public SetSlowChatActionMethod Method { get; set; } = SetSlowChatActionMethod.On;
        public double MessageCooldown { get; set; } = 30;

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static SetSlowChatActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<SetSlowChatActionConfigModel>(config);
        }
    }

    public enum SetSlowChatActionMethod
    {
        On,
        Off,
        Toggle
    }
}
