using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionAddOns : MonoBehaviour
{
    [SerializeField] private List<GameObject> addOns = new List<GameObject>();

    public bool EnableAddOn()
    {
        if (addOns.Count == 0 || addOns[addOns.Count - 1].activeInHierarchy) return false;

        for (int i = 0; i < addOns.Count; i++)
        {
            if (addOns[i].activeInHierarchy) continue;

            addOns[i].SetActive(true);
            break;
        }
        return true;
    }
}