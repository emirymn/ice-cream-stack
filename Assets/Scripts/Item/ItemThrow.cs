using UnityEngine;
using DG.Tweening;

public class ItemThrow : MonoBehaviour
{
    [SerializeField] private float minThrowDistance;
    [SerializeField] private float maxThrowDistance;
    [SerializeField] private float sideLimit;
    [Space]
    [SerializeField] private float jumpPower = 2f;
    [SerializeField] private float jumpTime = 0.5f;

    public Tween jumpTween;

    public void Throw()
    {
        if (jumpTween != null)
            jumpTween.Kill();

        float throwX = Random.Range(-sideLimit, sideLimit);
        float throwZ = Random.Range(minThrowDistance, maxThrowDistance);

        Vector3 targetPos = transform.position + new Vector3(throwX, 0f, throwZ);
        transform.DOJump(targetPos, jumpPower, 1, jumpTime).OnKill(() =>
        {
            transform.tag = "Collectable";
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        });
    }
}