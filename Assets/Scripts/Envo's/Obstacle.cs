using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        Items collidedItem = other.GetComponent<Items>();

        if (collidedItem == null) return;

        collidedItem.HitTheObstacle();
    }
}