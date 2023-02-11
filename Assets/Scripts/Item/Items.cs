using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private ItemSwipe mySwipeMovementScript;
    private ItemThrow myThrowScript;
    private StackSystem stackManager;
    //private ItemValue itemValue;
    //private ItemVFXController vfxController;

   

    #region MonoBehaviour METHODS
    private void Awake()
    {
        mySwipeMovementScript = GetComponent<ItemSwipe>();
        myThrowScript = GetComponent<ItemThrow>();
     //   itemValue = GetComponent<ItemValue>();
      //  vfxController = GetComponent<ItemVFXController>();
    }
    #endregion

    public void AddedToStack(StackSystem stackManager)
    {
      //  StaticEvents.onItemAddtotheStack?.Invoke(itemValue.TotalItemValue);
        this.stackManager = stackManager;
    }

    public void RemovedFromTheStack(bool onFinish = false)
    {
        if (!onFinish)
     //       StaticEvents.onItemRemovetotheStack?.Invoke(itemValue.TotalItemValue);

        stackManager = null;
        mySwipeMovementScript.enabled = false;

        if (!onFinish)
            myThrowScript.Throw();
    }


    public void FollowThis(Transform target)
    {
        mySwipeMovementScript.SetTarget(target);
        mySwipeMovementScript.enabled = true;
    }

    public void CollidedWithNewItem(Items newItem)
    {
        if(newItem != null && stackManager != null)
        stackManager.AddItemToStack(newItem);
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.collect);
    }

    public void HitTheObstacle()
    {
        if (stackManager == null) return;
        stackManager.RemoveItemFromStack(this);
        StaticEvents.onObstacle?.Invoke();
    }

    public void HitTheFinishFeet()
    {
        stackManager.RemoveFromStack(this);
     //   vfxController.EnableTrailParticle();
    }
    /*
    public void SelledItem()
    {
        StaticEvents.onItemSelled?.Invoke(itemValue.itemValue);
    }*/
}