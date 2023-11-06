using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T prefab;

    private List<T> pool;

    public Pool(T prefab, int poolLenght)
    {
        this.prefab = prefab;
        pool = new List<T>();

        for (int i = 0; i < poolLenght; i++)
        {
            CreateObject();
        }
    }

    public T GetObject()
    {
        var obj = pool.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj == null)
            obj = CreateObject();
        
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void Deactivate(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private T CreateObject()
    {
        var obj = GameObject.Instantiate(prefab);
        obj.gameObject.SetActive(false);
        pool.Add(obj);
        return obj;
    }

}
