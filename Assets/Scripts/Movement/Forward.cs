using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float moveSpeed;
   [SerializeField] GameManager gameManager;
  
      void Update()
    {
        if(gameManager.canForward)
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
