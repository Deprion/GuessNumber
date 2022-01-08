using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private int price;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button buyButton;
    private void Start()
    {
        text.text = $"Купить за {price}?";
    }
    private void Buy()
    {
        if (DataManager.s_inst.Money >= price)
        {
            DataManager.s_inst.Money -= price;
            PlayerPrefs.SetInt($"{sprite.name}", 1);
            buyButton.onClick.RemoveAllListeners();
            infoPanel.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt(ObjOfSprite().name, 0) == 0)
        {
            infoPanel.SetActive(!infoPanel.activeSelf);
            buyButton.onClick.AddListener(Buy);
        }
        else
        {
            DataManager.s_inst.ButtonImage = ObjOfSprite();
            Interface.s_inst.UpdateMoney();
        }
    }
    public Sprite ObjOfSprite()
    {
        return sprite;
    }
}
