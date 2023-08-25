using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
public enum JerkingType { Move, Rotate, Shake, Sequence, Value }

public class DoTween : MonoBehaviour
{
    public Transform twObject;
    public JerkingType jerkingType;
    public Transform target;
    public float value = 1f;

    [Button]
    public void StartJerking()
    {
        switch (jerkingType)
        {
            case JerkingType.Move:
                twObject.DOMove(target.position, value).SetEase(Ease.InSine).SetRelative().SetSpeedBased();
                break;
            case JerkingType.Rotate:
                twObject.DORotate(new Vector3(90, 90, 90), 2f)
                    //.SetEase(Ease.InSine)
                    .SetRelative()
                    .OnComplete(() => StartJerking());
                break;
            case JerkingType.Sequence:
                DG.Tweening.Sequence sequence = DOTween.Sequence();

                sequence.Append(twObject.DOMoveX(target.position.x, 1).SetRelative())
                    .Append(twObject.DORotate(new Vector3(0, 180, 0), 1))
                    .PrependInterval(1)
                    .Insert(0, twObject.DOScale(new Vector3(2f, 2f, 2f), sequence.Duration()));
                break;
            default: 
                break;
        }
    }
    [Button]
    public void Kill()
    {
        twObject.DOKill();
    }
}
