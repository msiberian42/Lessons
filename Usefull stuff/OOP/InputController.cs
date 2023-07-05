using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject go;

    private IControllable controlableObject;

    private void Start()
    {
        controlableObject = go.GetComponent<IControllable>();
        if (controlableObject == null ) 
        {
            throw new NullReferenceException("go doesnt have IControllable interface");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            controlableObject.Move();
        }

    }
}
