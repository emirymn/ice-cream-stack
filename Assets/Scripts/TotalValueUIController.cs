using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalValueUIController : MonoBehaviour
{

    // D��ER AYAKKABILARIN ET�KETLER�N� KALDIRICAZ HEPS�N� PLAYERIN ET�KET�NDE TOPLUCAZ
    [SerializeField] private TextMeshProUGUI valueTextMesh;

    private ItemValue myItemValueScript;

    #region MonoBehaviour METHODS
    private void Awake()
    {
        myItemValueScript = GetComponentInParent<ItemValue>();
    }
    private void OnEnable()
    {
        myItemValueScript.onItemValueChangedTotal += TotalUpdateValueText;
    }

    private void OnDisable()
    {
        myItemValueScript.onItemValueChangedTotal -= TotalUpdateValueText;
    }
    #endregion
    private void TotalUpdateValueText(float value)
    {
        
        valueTextMesh.text = value.ToString("F2") + " $";
    }
}

