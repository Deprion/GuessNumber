using UnityEngine;
using UnityEngine.UI;

public class ButtonShopClose : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Button btnBuy;
    private void OnMouseDown()  
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
        btnBuy.onClick.RemoveAllListeners();
    }
}
