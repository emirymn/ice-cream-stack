using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstItemSpawner : MonoBehaviour
{
    [SerializeField] private Items itemPrefab;

    #region MonoBehaviour METHODS
    private void Awake()
    {
        SpawnItem();
    }
    #endregion

    public void SpawnItem()
    {
        StackSystem stackManager = GetComponent<StackSystem>();

        if (stackManager == null) return;

        Items newItem = Instantiate(itemPrefab);
        stackManager.AddItemToStack(newItem);
    }
}