using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Transform target;

    private void LateUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (target == null) return;

        Vector3 currentPos = transform.localPosition;
        currentPos.x = Mathf.Lerp(currentPos.x, target.localPosition.x, moveSpeed * Time.deltaTime);
        transform.localPosition = currentPos;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}