using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionUpgraderPortal : MonoBehaviour
{
    [SerializeField] private int upgradeVersitonTo;

    #region EVENT
    public event Action onVersionUpgraded;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        AudioSources.instance.audioS.PlayOneShot(AudioSources.instance.upgrade);
        ItemVersionController versionController = other.GetComponent<ItemVersionController>();
        if (versionController == null || !versionController.CanUpgradedTo(upgradeVersitonTo)) return;
        onVersionUpgraded?.Invoke();
        versionController.UpgradeVerisonTo(upgradeVersitonTo);
        StaticEvents.UpgradePlayer?.Invoke();
    }
}