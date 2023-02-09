using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStacker : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;

    private List<Items> itemStack = new List<Items>();

    public void AddItemToStack(Items newItem)
    {
        itemStack.Add(newItem);
     //   newItem.AddedToStack(this);
        newItem.tag = "Collected";
        newItem.transform.SetParent(itemHolder);

        if (itemStack.Count > 1)
        {
            Items previousItem = itemStack[itemStack.IndexOf(newItem) - 1];
            newItem.transform.localPosition = previousItem.transform.localPosition + (Vector3.forward * 5);
            newItem.FollowThis(previousItem.transform);
        }
        else
        {
            newItem.transform.localPosition = Vector3.zero;
            newItem.FollowThis(transform);
        }
    }

    public void RemoveItemFromStack(Items item)
    {
        RemoveFromStack(item, false);

        if (itemStack.Count == 0)
        {
            StaticEvents.onLevelFailed?.Invoke();
        }
    }

    public void RemoveFromStack(Items item, bool levelEnd = true)
    {
        if (!itemStack.Contains(item)) return;

        List<Items> itemList = new List<Items>(itemStack);
        int indexOfItem = itemStack.IndexOf(item);
        itemStack.RemoveRange(indexOfItem, itemStack.Count - indexOfItem);

        for (int i = itemList.Count - 1; i >= indexOfItem; i--)
        {
            Items removedItem = itemList[i];
            itemList.RemoveAt(i);
            {
                removedItem.transform.SetParent(null);
                removedItem.RemovedFromTheStack(levelEnd);
            }
        }
    }
}