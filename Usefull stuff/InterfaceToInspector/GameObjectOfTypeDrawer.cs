using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

[CustomPropertyDrawer(typeof(GameObjectOfTypeAttribute))]
public class GameObjectOfTypeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bool isFieldGameObject = IsFieldGameObject();

        if (!isFieldGameObject)
        {
            DrawError(position);
            return;
        }

        var gootAttribute = attribute as GameObjectOfTypeAttribute;
        var requiredType = gootAttribute.type;

        CheckDragAndDrops(position, requiredType);
        CheckValues(property, requiredType);
        DrawObjectField(property, position, label, gootAttribute.allowSceneObjects);
    }
    
    private bool IsFieldGameObject()
    {
        return fieldInfo.FieldType == typeof(GameObject) ||
            typeof(IEnumerable<GameObject>).IsAssignableFrom(fieldInfo.FieldType);
    }

    private void DrawError(Rect position)
    {
        EditorGUI.HelpBox(position, "GameObjectOfTypeAttribute works only with GameObject references", MessageType.Error);
    }

    private void CheckDragAndDrops(Rect position, Type requiredType)
    {
        if (position.Contains(Event.current.mousePosition))
        {
            var draggedObjectsCount = DragAndDrop.objectReferences.Length;

            for (int i = 0; i < draggedObjectsCount; i++)
            {
                if (!IsValidObject(DragAndDrop.objectReferences[i], requiredType))
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                    break;
                }
            }
        }
    }
    private bool IsValidObject(UnityEngine.Object o, Type requiredType)
    {
        bool result = false;

        var go = o as GameObject;

        if (go != null)
        {
            result = go.GetComponent(requiredType) != null;
        }

        return result;
    }
    private void DrawObjectField(SerializedProperty property, Rect position, GUIContent label, bool allowSceneObjects)
    {
        property.objectReferenceValue = EditorGUI.ObjectField(position,
            label,
            property.objectReferenceValue,
            typeof(GameObject), allowSceneObjects);
    }
    private void CheckValues(SerializedProperty property, Type requiredType)
    {
        if (property.objectReferenceValue != null)
        {
            if (!IsValidObject(property.objectReferenceValue, requiredType))
            {
                property.objectReferenceValue = null;
            }
        }
    }
}
