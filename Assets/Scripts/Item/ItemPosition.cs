using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPosition : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 position = transform.position + Vector3.up * 0.5f;
        Gizmos.DrawSphere(position, 0.75f);
    }
}