using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonRewardAd : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button close, ad;
    [SerializeField] private TMP_Text text;
    public static ButtonRewardAd s_inst;
    private void Start()
    {
        s_inst = this;
        if (!AdsManager.s_inst.CheckForInit())
        {
            ad.interactable = false;
            text.text = "Реклама недоступна";
        }
        else
        {
            text.text = "Посмотреть рекламу и получить 10 монет?";
        }
    }
    private void OnMouseDown()
    {
        AdsManager.s_inst.LoadRewardAd();
        text.text = "Реклама загружается";
        close.interactable = false;
        ad.interactable = false;
    }
    public void UnlockMenu()
    {
        close.interactable = true;
        ad.interactable = true;
        panel.SetActive(false);
        text.text = "Посмотреть рекламу и получить 10 монет?";
    }
}
