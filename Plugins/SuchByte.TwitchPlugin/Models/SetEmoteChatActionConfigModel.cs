using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SuchByte.TwitchPlugin.Models
{
    public class SetEmoteChatActionConfigModel : ISerializableConfiguration
    {
        public SetEmoteChatActionMethod Method { get; set; } = SetEmoteChatActionMethod.On;

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static SetEmoteChatActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<SetEmoteChatActionConfigModel>(config);
        }
    }

    public enum SetEmoteChatActionMethod
    {
        On,
        Off,
        Toggle
    }
}
