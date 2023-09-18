using UnityEngine;

public class GameObjectOfTypeAttributeExample : MonoBehaviour
{
    [SerializeField, GameObjectOfType(typeof(IExampleObject))] 
    private GameObject exampleObject;
}
