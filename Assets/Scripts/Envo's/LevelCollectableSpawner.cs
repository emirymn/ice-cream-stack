using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollectableSpawner : MonoBehaviour
{
    [SerializeField] private Transform collectablesParent;
    [Space]
    [SerializeField] private List<Items> itemPrefabs = new List<Items>();

    private void Awake()
    {
        SpawnCollectablesRoutine();
    }

    private void SpawnCollectablesRoutine()
    {
        Items levelItem = itemPrefabs[Random.Range(0, itemPrefabs.Count)];
        ItemPosition[] itemPositions = FindObjectsOfType<ItemPosition>();

        for (int i = itemPositions.Length - 1; i >= 0; i--)
        {
            Instantiate(levelItem, itemPositions[i].transform.position, Quaternion.identity, collectablesParent);
            Destroy(itemPositions[i].gameObject);
        }
    }
}