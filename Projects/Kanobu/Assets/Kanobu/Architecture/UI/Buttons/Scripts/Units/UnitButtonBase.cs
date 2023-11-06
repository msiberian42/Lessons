using UnityEngine;
using UnityEngine.UI;

public abstract class UnitButtonBase : MonoBehaviour
{
    [SerializeField] protected UnitType unitType;
    [SerializeField] protected Image image;

    protected UnitColor unitColor;
    protected Button button;
    protected float normalAlpha = 1f;
    protected float highlightedAlpha = 0.5f;
    protected bool unitChoosed = false;

    protected virtual void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
        SpawnFactory.OnUnitSpawnedEvent += OnUnitSpawned;

        UnitButtonManager.CancelChoice(unitColor);
    }
    protected virtual void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClicked);
        SpawnFactory.OnUnitSpawnedEvent -= OnUnitSpawned;
    }

    protected void OnButtonClicked()
    {
        if (unitChoosed)
        {
            unitChoosed = false;
            ReleaseButton();
            return;
        }

        ChooseUnit();
        ColorButton();
    }
    protected void ChooseUnit()
    {
        UnitButtonManager.ChooseUnit(unitType, unitColor);
        unitChoosed = true;
    }

    protected void ColorButton()
    {
        Color color = image.color;
        color.a = highlightedAlpha;
        image.color = color;
    }
    protected void ReleaseButton()
    {
        unitChoosed = false;

        Color color = image.color;
        color.a = normalAlpha;
        image.color = color;
    }
    protected void OnUnitSpawned(UnitConstructor unit)
    {
        if (unit.unitColor == unitColor)
        {
            ReleaseButton();
            UnitButtonManager.CancelChoice(unitColor);
        }
    }
}
