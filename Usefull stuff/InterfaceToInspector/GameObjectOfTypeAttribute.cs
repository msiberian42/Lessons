using System;
using UnityEngine;

public class GameObjectOfTypeAttribute : PropertyAttribute
{
    public Type type { get; }
    public bool allowSceneObjects { get; }

    public GameObjectOfTypeAttribute (Type type, bool allowSceneObjects = true)
    {
        this.type = type;
        this.allowSceneObjects = allowSceneObjects;
    }
}
