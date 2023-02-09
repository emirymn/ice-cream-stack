using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVersionController : MonoBehaviour
{
    [SerializeField] int starterIndex = 0;
    [Space]
    [SerializeField] private List<Versions> itemVersions = new List<Versions>();

    public int currentIndex = 0;

    private VersionAnimationPlayer myAnimaitonPlayer;
  //  private PutItemInBox shoeBoxingScript;

    #region EVENTS
    public event Action onVersionUpgrade;
    public event Action onAddOnEnabled;
    public event Action<Material> onMaterialChange;
    #endregion

    #region EDITOR
    private void OnValidate()
    {
        starterIndex = Mathf.Clamp(starterIndex, 0, itemVersions.Count - 1);
    }
    #endregion

    #region MonoBehavior METHODS
    private void Awake()
    {
        myAnimaitonPlayer = GetComponent<VersionAnimationPlayer>();
    }

    private void Start()
    {
        EnableStartIndexVersion();
    }
    #endregion

    private void EnableStartIndexVersion()
    {
        for (int i = 0; i < itemVersions.Count; i++)
        {
            itemVersions[i].gameObject.SetActive(false);
        }

        currentIndex = starterIndex;
        itemVersions[currentIndex].gameObject.SetActive(true);
    }

    public void UpgradeVerison()
    {
        int newIndex = Mathf.Clamp(currentIndex + 1, 0, itemVersions.Count - 1);

        if (currentIndex == newIndex) return;

        itemVersions[currentIndex].gameObject.SetActive(false);
        currentIndex = newIndex;
        itemVersions[currentIndex].gameObject.SetActive(true);
        myAnimaitonPlayer.RotateAnimation();
        onVersionUpgrade?.Invoke();
    }

    public void UpgradeVerisonTo(int newIndex)
    {
        if (currentIndex >= newIndex || newIndex >= itemVersions.Count) return;

        itemVersions[currentIndex].gameObject.SetActive(false);
        currentIndex = newIndex;
        itemVersions[currentIndex].gameObject.SetActive(true);
        myAnimaitonPlayer.PlayScaleAnimation();
        myAnimaitonPlayer.PlayJumpAndRotateAnimation();
        onVersionUpgrade?.Invoke();
        
    }

    public IEnumerator ChangeItemMaterials(Material newMaterials)
    {
        float delay = myAnimaitonPlayer.PlayPutOnPaintAreaAnim();

        onMaterialChange?.Invoke(newMaterials);
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < itemVersions.Count; i++)
        {
            itemVersions[i].ChangeTheMaterial(newMaterials);
        }
        myAnimaitonPlayer.PlayScaleAnimation();
        myAnimaitonPlayer.PlayPutOffPaintAreaAnim();
        yield return new WaitForSeconds(delay);

    }

    public void ActivateAddOn()
    {
        if (!itemVersions[currentIndex].AddOnEnabled) return;

        myAnimaitonPlayer.PlayJumpAndRotateAnimation();
        onAddOnEnabled?.Invoke();
    }

    public bool CanUpgradedTo(int index)
    {
        if (currentIndex >= index || (index - currentIndex) != 1) return false;

        return true;
    }
}