using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        var allChestInfos = Resources.LoadAll<ChestInfo>("");
        foreach (var chestInfo in allChestInfos)
        {
            Debug.Log(chestInfo.id);
        }
    }
}
