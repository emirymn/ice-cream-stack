using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected bool canMove;

    protected virtual void StartMoving()
    {
        canMove = true;
    }

    protected virtual void StopMoving()
    {
        canMove = false;
    }
    protected virtual void StopMovingForward()
    {
        canMove = false;
    }
}