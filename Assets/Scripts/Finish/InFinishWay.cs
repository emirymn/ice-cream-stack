using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFinishWay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StaticEvents.onLevelEndReached?.Invoke();
    }
}
