using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Versions : MonoBehaviour
{
    private VersionAddOns myAddOnController;

    public bool AddOnEnabled
    {
        get
        {
            if (myAddOnController == null)
                myAddOnController = GetComponent<VersionAddOns>();

            if (myAddOnController == null)
            {
                return false;
            }
            return myAddOnController.EnableAddOn();
        }
    }

    public void ChangeTheMaterial(Material newMaterial)
    {
        Paintable[] paintables = GetComponentsInChildren<Paintable>(true);
        if (paintables == null || paintables.Length == 0) return;

        for (int i = 0; i < paintables.Length; i++)
        {
            paintables[i].ChangeTheMaterial(newMaterial);
        }
    }
}