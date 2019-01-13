using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotForMeCore.Storage
{
    public interface IDataStorage
    {
        void Store(object obj, string key);

        T RestoreObject<T>(string key);
    }
}
