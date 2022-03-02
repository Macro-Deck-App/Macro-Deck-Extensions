using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SuchByte.TwitchPlugin.Models
{
    public class PlayAdActionConfigModel : ISerializableConfiguration
    {
        public int Length { get; set; } = 30;

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        public static PlayAdActionConfigModel Deserialize(string config)
        {
            return ISerializableConfiguration.Deserialize<PlayAdActionConfigModel>(config);
        }
    }
}
