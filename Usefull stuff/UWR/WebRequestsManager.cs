using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Networking;
using System.Collections;

public class WebRequestsManager : MonoBehaviour
{
    private const string URL = "https://dotween.demigiant.com/documentation.php";

    private Coroutine exampleR;
    private Coroutine loadR;

    [Button]
    public void GetData() => StartCoroutine(GetDataRoutine());

    [Button]
    public void LoadData()
    {
        GetData();
    }

    private IEnumerator GetDataRoutine()
    {
        Debug.Log("Loading...");

        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            loadR = StartCoroutine(ShowProgress(request));

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }

            StopCoroutine(loadR);
        }
    }

    private IEnumerator ShowProgress(UnityWebRequest request)
    {
        while (true)
        {

            Debug.Log(request.downloadProgress);

            yield return null;
        }
    }

    [Button]
    public void PostData() => StartCoroutine(PostDataRoutine());

    private IEnumerator PostDataRoutine()
    {
        Debug.Log("Loading...");

        WWWForm form = new WWWForm();
        form.AddField("title", "test data");
        using (UnityWebRequest request = UnityWebRequest.Post(URL, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
                Debug.Log(request.downloadHandler.text);
        }
    }

    [Button]
    public void StartExample()
    {
        exampleR = StartCoroutine(ExampleRoutine());
    }


    [Button]
    public void StopExample() => StopCoroutine(exampleR);

    private IEnumerator ExampleRoutine()
    {
        int n = 0;
        while (true)
        {

            yield return null;

            n++;
            Debug.Log(n);
        }

    }
}
