using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemValueFollow : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

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
}
