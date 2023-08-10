using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class JsonToFileStorageService : IStorageService
{
    private bool isInProgressNow;

    public void Save(string key, object data, Action<bool> callback = null)
    {
        if (!isInProgressNow)
        {
            SavAsync(key, data, callback);
        }
        else
        {
            callback?.Invoke(false);
        }

        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }
        
        callback?.Invoke(true);
    }
    public void Load<T>(string key, Action<T> callback)
    {
        string path = BuildPath(key);

        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);

            callback.Invoke(data);
        }
    }

    private async void SavAsync(string key, object data, Action<bool> callback)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (var fileStream = new StreamWriter(path))
        {
            await fileStream.WriteAsync(json);
        }

        callback?.Invoke(true);
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
