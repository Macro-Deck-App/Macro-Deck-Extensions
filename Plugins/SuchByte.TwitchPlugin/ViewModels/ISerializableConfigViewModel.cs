using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.ViewModels
{
    internal interface ISerializableConfigViewModel
    {
        protected ISerializableConfiguration SerializableConfiguration { get; }

        void SetConfig();

        bool SaveConfig();
    }
}
