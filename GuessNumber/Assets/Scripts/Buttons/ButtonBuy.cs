using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private int price;
    [SerializeField] private GameObject infoPanel, container, closeButton, bought, toBuy;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button buyButton;
    private void Start()
    {
        text.text = $"Купить за {price}?";
        CheckAvailable();
    }
    private void CheckAvailable()
    {
        if (PlayerPrefs.GetInt(ObjOfSprite().name, 0) != 0)
        {
            bought.SetActive(true);
            toBuy.SetActive(false);
        }
        else
        {
            toBuy.SetActive(true);
            bought.SetActive(false);
        }
    }
    private void Buy()
    {
        if (DataManager.s_inst.Money >= price)
        {
            DataManager.s_inst.Money -= price;
            PlayerPrefs.SetInt($"{sprite.name}", 1);
            buyButton.onClick.RemoveAllListeners();
            Interface.s_inst.UpdateMoney();
            infoPanel.SetActive(false);
            container.SetActive(true);
            CheckAvailable();
        }
    }
    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt(ObjOfSprite().name, 0) == 0)
        {
            infoPanel.SetActive(!infoPanel.activeSelf);
            container.SetActive(!container.activeSelf);
            buyButton.onClick.AddListener(Buy);
        }
        else
        {
            DataManager.s_inst.ButtonImage = ObjOfSprite();
            closeButton.GetComponent<Image>().sprite = DataManager.s_inst.ButtonImage;
            closeButton.GetComponent<Image>().color = DataManager.s_inst.ButtonColor;
        }
    }
    public Sprite ObjOfSprite()
    {
        return sprite;
    }
}
