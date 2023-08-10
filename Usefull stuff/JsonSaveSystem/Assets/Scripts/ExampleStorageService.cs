using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExampleStorageService : MonoBehaviour
{
    private const string key = "example_save";
    private IStorageService storageService;

    private void Start()
    {
        storageService = new JsonToFileStorageService();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExampleStorageItem e = new ExampleStorageItem();
            e.stringParameter = "example";
            e.dictionaryParameter = new Dictionary<string, int>
            {
                {"par 1", 20},
                {"mob", 200}
            };

            storageService.Save(key, e);
            Debug.Log("Data saved");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            storageService.Load<ExampleStorageItem>(key, e =>
            {
                Debug.Log($"Loaded. String: {e.stringParameter}, " +
                    $"dictionary[0]: {e.dictionaryParameter.Keys.ElementAt(0)} : {e.dictionaryParameter.Values.ElementAt(0)}, " +
                    $"dictionary[1]: {e.dictionaryParameter.Keys.ElementAt(1)} : {e.dictionaryParameter.Values.ElementAt(01)}.");
            });
        }
    }
}

public class ExampleStorageItem
{
    [JsonProperty (PropertyName = "str")]
    public string stringParameter { get; set; }
    [JsonProperty(PropertyName = "dic")]
    public Dictionary<string, int> dictionaryParameter { get; set; }
}
