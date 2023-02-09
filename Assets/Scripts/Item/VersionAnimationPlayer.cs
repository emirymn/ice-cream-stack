using UnityEngine;
using DG.Tweening;

public class VersionAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Transform shoeParent;
    [Space]
    [Header("Version Upgrade Animation")]
    [SerializeField] private float upgradeAnimTime = 1.2f;
    [SerializeField] private float riseValue = 2f;
    [SerializeField] private float rotateValue = 720f;
    [Header("Size Change Animation")]
    [SerializeField] private float sclaeTo = 1.2f;
    [SerializeField] private float sclaeanimTime = 0.6f;
    [Header("Painting Animation")]
    [SerializeField] private float paintAnimTime = 1f;
    [SerializeField] private float loweringValue = 2f;

    private Sequence versionUpgradeSequence;
    private Sequence sizeChangeSequence;

    public void PlayScaleAnimation()
    {
        if (sizeChangeSequence != null)
        {
            sizeChangeSequence.Kill();
        }
        float defaultScale = shoeParent.localScale.x;

        sizeChangeSequence = DOTween.Sequence();
        Tween tween = shoeParent.DOScale(sclaeTo, sclaeanimTime / 2);
        sizeChangeSequence.Append(tween);
        tween = shoeParent.DOScale(defaultScale, sclaeanimTime / 2);
        sizeChangeSequence.Append(tween);

        sizeChangeSequence.OnKill(() =>
        {
            shoeParent.localScale = defaultScale * Vector3.one;
        });
    }

    public void PlayJumpAndRotateAnimation()
    {
        if (versionUpgradeSequence != null)
        {
            versionUpgradeSequence.Kill();
        }
        float localY = shoeParent.localPosition.y;
        float localRotationY = shoeParent.localEulerAngles.y;

        versionUpgradeSequence = DOTween.Sequence();
        Tween tween = shoeParent.DOLocalMoveY(localY + riseValue, upgradeAnimTime / 4);
        versionUpgradeSequence.Append(tween);
        tween = shoeParent.DOLocalRotate(Vector3.up * rotateValue, upgradeAnimTime / 2, RotateMode.LocalAxisAdd);
        versionUpgradeSequence.Append(tween);
        tween = shoeParent.DOLocalMoveY(localY, upgradeAnimTime / 4);
        versionUpgradeSequence.Append(tween);

        versionUpgradeSequence.OnKill(() =>
        {
            Vector3 localPos = shoeParent.localPosition;
            localPos.y = localY;
            Vector3 localAngle = shoeParent.localEulerAngles;
            localAngle.y = localRotationY;
            shoeParent.localEulerAngles = localAngle;
        });
    }

    public void RotateAnimation()
    {
        float localRotationY = shoeParent.localEulerAngles.y;
        shoeParent.DOLocalRotate(Vector3.up * rotateValue, upgradeAnimTime / 2, RotateMode.LocalAxisAdd).OnKill(() =>
        {
            Vector3 localAngle = shoeParent.localEulerAngles;
            localAngle.y = localRotationY;
            shoeParent.localEulerAngles = localAngle;
        });
    }

    public float PlayPutOnPaintAreaAnim()
    {
        shoeParent.DOLocalMoveY(shoeParent.localPosition.y - loweringValue, paintAnimTime / 2);

        return paintAnimTime / 2;
    }

    public void PlayPutOffPaintAreaAnim()
    {
        shoeParent.DOLocalMoveY(shoeParent.localPosition.y + loweringValue, paintAnimTime / 2);
    }

    public void PlayCustomRotateAroundAnim(float angle, float time)
    {
        shoeParent.DOLocalRotate(Vector3.up * angle, time, RotateMode.LocalAxisAdd);
    }
}