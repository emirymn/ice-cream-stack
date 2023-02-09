using UnityEngine;

public class ItemMaterialChangerPortal : MonoBehaviour
{
    [SerializeField] private Material paintMaterial;

    private void OnTriggerEnter(Collider other)
    {
        ItemVersionController versionController = other.GetComponent<ItemVersionController>();
        if (versionController == null) return;

        StartCoroutine(versionController.ChangeItemMaterials(paintMaterial));
    }
}