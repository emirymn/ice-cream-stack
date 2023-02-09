using UnityEngine;
using TMPro;

public class SellItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueTextMesh;
    private float ourMoney;

    #region MonoBehaviour METHODS
    private void OnEnable()
    {
        StaticEvents.onItemSelled += SelledItemUITextChange;
    }

    private void OnDisable()
    {
        StaticEvents.onItemSelled -= SelledItemUITextChange;
    }
    #endregion

    public void SelledItemUITextChange(float value)
    {
        ourMoney += value;
        valueTextMesh.text = ourMoney.ToString("F2") + " $";
    }
}
