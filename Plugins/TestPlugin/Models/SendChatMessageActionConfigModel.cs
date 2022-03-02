using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SuchByte.TwitchPlugin.Models
{
    public class SendChatMessageActionConfigModel : ISerializableConfiguration
    {
        public string Message { get; set; } = "";

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static SendChatMessageActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<SendChatMessageActionConfigModel>(config);
        }
    }
}
