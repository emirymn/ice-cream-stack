using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalValueUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueTextMesh;
    public float totalValue;

    #region EVENT LISTENERS
    private void OnLevelEnded()
    {
      //  FindObjectOfType<LevelEndMoney>().StartLevelEndRoutine(totalValue);
    }
    #endregion

    #region MonoBehaviour METHODS
    private void OnEnable()
    {
        StaticEvents.onItemValueIncreaseChange += OnValueIncrease;
        StaticEvents.onItemAddtotheStack += OnValueIncrease;
        StaticEvents.onItemValueDecreaseChange += OnValueDecrease;
        StaticEvents.onItemRemovetotheStack += OnValueDecrease;
        //LevelEnded
        StaticEvents.onLevelEndReachedFinish += OnLevelEnded;
    }
    private void OnDisable()
    {
        StaticEvents.onItemValueIncreaseChange -= OnValueIncrease;
        StaticEvents.onItemAddtotheStack -= OnValueIncrease;
        StaticEvents.onItemValueDecreaseChange -= OnValueDecrease;
        StaticEvents.onItemRemovetotheStack -= OnValueDecrease;
        //LevelEnded
        StaticEvents.onLevelEndReachedFinish -= OnLevelEnded;
    }
    #endregion

    private void OnValueIncrease(float value)
    {
        totalValue += value;
        UpdateValueText();
    }
    private void OnValueDecrease(float value)
    {
        totalValue -= value;
        UpdateValueText();
    }
    private void UpdateValueText()
    {
        valueTextMesh.text = totalValue.ToString("F2") + " $";
    }
}
