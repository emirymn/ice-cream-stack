using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionDetection : MonoBehaviour
{
    private Items myItemScript;

    private void Awake()
    {
        myItemScript = GetComponent<Items>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Collected") || other.CompareTag("Collected")) return;

        Items newItem = other.GetComponent<Items>();
        if (newItem == null) return;

        myItemScript.CollidedWithNewItem(newItem);
    }
}