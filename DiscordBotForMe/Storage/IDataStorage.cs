using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotForMe.Storage
{
    public interface IDataStorage
    {
        void Store(object obj, string path);

        T RestoreObject<T>(string path);
    }
}
