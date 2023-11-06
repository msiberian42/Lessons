using UnityEngine;
using TMPro;
using System;

public class InputFieldHandler : MonoBehaviour
{
    [SerializeField] private KeyCode applyKey = KeyCode.Return;

    public event Action<string> OnTextApplied;

    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }
    private void Start()
    {
        Activate();
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            Deactivate();
            return;
        }

        if (!inputField.isFocused)
        {
            Activate();
        }

        if (Input.GetKeyDown(applyKey))
        {
            ApplyText();
        }
    }
    
    private void ApplyText()
    {
        OnTextApplied?.Invoke(inputField.text.ToLower());
        ClearField();
    }
    private void Activate()
    {
        inputField.ActivateInputField();
    }
    private void Deactivate()
    {
        inputField.DeactivateInputField();
    }
    private void ClearField()
    {
        inputField.text = null;
    }
}
