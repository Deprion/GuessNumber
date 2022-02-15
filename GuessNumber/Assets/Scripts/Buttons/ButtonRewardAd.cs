using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonRewardAd : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button close;
    [SerializeField] private BoxCollider2D ad;
    [SerializeField] private TMP_Text text;
    public static ButtonRewardAd s_inst;
    private void Start()
    {
        s_inst = this;
        if (!AdsManager.s_inst.CheckForInit())
        {
            ad.enabled = false;
            text.text = LanguageManager.inst.GetString("no_ad");
        }
        else
        {
            text.text = LanguageManager.inst.GetString("ad");
        }
    }
    private void OnMouseDown()
    {
        AdsManager.s_inst.ShowAd("Rewarded_Android");
        text.text = LanguageManager.inst.GetString("ad_load");
        close.interactable = false;
        ad.enabled = false;
        DataManager.s_inst.Money += 10;
        Interface.s_inst.UpdateMoney();
    }
    public void UnlockMenu()
    {
        close.interactable = true;
        ad.enabled = true;
        panel.SetActive(false);
        text.text = LanguageManager.inst.GetString("ad");
    }
}
