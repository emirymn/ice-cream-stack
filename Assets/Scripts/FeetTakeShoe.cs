using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FeetTakeShoe : MonoBehaviour
{
    [SerializeField] Transform shoeHolder;
    [SerializeField] float moveTime = 0.5f;

    #region MonoBehaviour METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            Items collidedItem = other.GetComponent<Items>();

            if (collidedItem == null) return;

           // collidedItem.HitTheFinishFeet();
           // collidedItem.SelledItem();
            other.transform.SetParent(shoeHolder);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            other.transform.DOLocalMove(Vector3.zero, moveTime);
            other.transform.DOLocalRotate(Vector3.zero, moveTime);
        }
    }
    #endregion
}
