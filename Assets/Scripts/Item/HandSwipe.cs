using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSwipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Transform target;
    private void Start()
    {
      target = transform.parent.transform;
    }
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
