using UnityEngine;
using UnityEngine.UI;

public class ButtonShopClose : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel, container;
    [SerializeField] private Button btnBuy;
    private void OnMouseDown()  
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
        container.SetActive(!container.activeSelf);
        btnBuy.onClick.RemoveAllListeners();
    }
}
