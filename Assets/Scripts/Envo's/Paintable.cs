using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    [SerializeField] private int materialIndex = 0;
    private MeshRenderer myMeshRenderer;

    #region PROPERTIES
    private MeshRenderer MyMeshRenderer
    {
        get
        {
            if (myMeshRenderer == null)
                myMeshRenderer = GetComponent<MeshRenderer>();

            return myMeshRenderer;
        }
    }
    #endregion

    public void ChangeTheMaterial(Material newMaterial)
    {
        Material[] materials = MyMeshRenderer.materials;
        materials[materialIndex] = newMaterial;
        MyMeshRenderer.materials = materials;
    }
}