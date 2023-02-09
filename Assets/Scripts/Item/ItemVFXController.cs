using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVFXController : MonoBehaviour
{
    [SerializeField] private ParticleSystem itemUpgradedParticle;
    [SerializeField] private ParticleSystem itemMaterialChangeParticle;
    [SerializeField] private ParticleSystem itemValueIncreaseParticle;
    [SerializeField] private ParticleSystem itemAddOnEnabledParticle;
    [Space]
    [SerializeField] private ParticleSystem trailParticle;

    #region MonoBehaviour METHODS
    private void OnEnable()
    {
        ItemVersionController versionController = GetComponent<ItemVersionController>();
        versionController.onAddOnEnabled += PlayItemAddOnEnabledParticle;
        versionController.onMaterialChange += PlayItemMaterialChangeParticle;
        versionController.onVersionUpgrade += PlayItemUpgradedParticle;
        //    GetComponent<ItemValue>().onItemValueChanged += PlayItemValueIncreaseParticle;
    }
    private void OnDisable()
    {
        ItemVersionController versionController = GetComponent<ItemVersionController>();
        versionController.onAddOnEnabled -= PlayItemAddOnEnabledParticle;
        versionController.onMaterialChange -= PlayItemMaterialChangeParticle;
        versionController.onVersionUpgrade -= PlayItemUpgradedParticle;
        GetComponent<ItemVersionController>().onVersionUpgrade -= PlayItemUpgradedParticle;
    }
    #endregion

    private void PlayItemUpgradedParticle()
    {
        if (itemUpgradedParticle == null) return;
        itemUpgradedParticle.Play();
    }

    private void PlayItemMaterialChangeParticle(Material material)
    {
        if (itemMaterialChangeParticle == null) return;
        //  var particleMain = itemMaterialChangeParticle.main;
        //  particleMain.startColor = material.color;
        itemMaterialChangeParticle.Play();
    }

    private void PlayItemValueIncreaseParticle(float increase)
    {
        if (itemValueIncreaseParticle == null) return;
        itemValueIncreaseParticle.Play();
    }

    private void PlayItemAddOnEnabledParticle()
    {
        if (itemAddOnEnabledParticle == null) return;
        itemAddOnEnabledParticle.Play();
    }

    public void EnableTrailParticle()
    {
        trailParticle.gameObject.SetActive(true);
    }
}