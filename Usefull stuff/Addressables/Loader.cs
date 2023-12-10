using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Loader : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject _cube;

    private GameObject _instanceReference;

    [Button]
    private void LoadCubeAsync()
    {
        _cube.LoadAssetAsync()
            .Completed += OnAddressableLoaded;

        // _cube.InstantiateAsync();
    }

    [Button]
    private void UnloadCube()
    {
        _cube.ReleaseInstance(_instanceReference);
        Destroy(_instanceReference);
    }

    private void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("loaded");
            _instanceReference = Instantiate(handle.Result);
        }
        else
        {
            Debug.LogError("loading asset failed!");
        }
    }
}
