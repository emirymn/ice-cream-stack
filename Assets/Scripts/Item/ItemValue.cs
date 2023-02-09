using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemValue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ticketText, totalCashText;
    public float itemValue { get; private set; }
    public float LevelTotalItemValue { get; private set; }
    public float TotalItemValue { get; private set; }
    [Space]
    [SerializeField] private float valueIncreaseOnUpgrade = 4.763f;
    [SerializeField] private float firstPrice = 4.763f;

    #region EVENT LISTENER
    private void OnValueChanged()
    {
        IncreaseValueBy(valueIncreaseOnUpgrade);
    }
    #endregion

    #region EVENTS
    public event Action<float> onItemValueChanged;
    public event Action<float> onItemValueChangedTotal;

    #endregion

    #region MonoBehaviour METHODS
    private void Awake()
    {
        TicketTextUpgrade(firstPrice);
    }
    private void OnEnable()
    {
        GetComponent<ItemVersionController>().onAddOnEnabled += OnValueChanged;
        GetComponent<ItemVersionController>().onVersionUpgrade += OnValueChanged;
        onItemValueChanged += TicketTextUpgrade;
        StaticEvents.onSellItem += UpgradeTotalCash;
    }

    private void OnDisable()
    {
        GetComponent<ItemVersionController>().onAddOnEnabled -= OnValueChanged;
        GetComponent<ItemVersionController>().onVersionUpgrade -= OnValueChanged;
        onItemValueChanged -= TicketTextUpgrade;
        StaticEvents.onSellItem -= UpgradeTotalCash;
    }
    #endregion

    public void IncreaseValueBy(float increase)
    {
        itemValue += increase;
        TotalItemValue += itemValue;
        LevelTotalItemValue += itemValue;
        GameManager.instance.levelTotalCash += LevelTotalItemValue;
        StaticEvents.onItemValueIncreaseChange?.Invoke(increase);
        onItemValueChanged?.Invoke(itemValue);
        onItemValueChangedTotal?.Invoke(TotalItemValue);
    }

    public void DecreaseValueBy(float decrease)
    {
        itemValue -= decrease;
        TotalItemValue -= itemValue;
        LevelTotalItemValue += itemValue;
        GameManager.instance.levelTotalCash = LevelTotalItemValue;
        if (itemValue < 0f)
            itemValue = 0f;

        StaticEvents.onItemValueDecreaseChange?.Invoke(decrease);
        onItemValueChanged?.Invoke(itemValue);
        onItemValueChangedTotal?.Invoke(TotalItemValue);
    }
    private void TicketTextUpgrade(float value)
    {
        //  ticketText.text = value.ToString("F2") + " $";
        ticketText.text = value + " $";
    }
    public void UpgradeTotalCash(float value)
    {
        GameManager.instance.totalCash += value;
        PlayerPrefs.SetFloat("totalCash", GameManager.instance.totalCash);
        PlayerPrefs.Save();
        GameManager.instance.UpgradeTotalCashUI();
    }
}