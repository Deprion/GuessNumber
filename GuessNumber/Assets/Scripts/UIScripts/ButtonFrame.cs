using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFrame : MonoBehaviour
{
    [SerializeField] private bool isTextNeed;
    [SerializeField] private bool isMulti;
    private Image image;
    private TMP_Text txt;
    private void Awake()
    {
        image = GetComponent<Image>();
        if (!isMulti && isTextNeed)
        {
            txt = transform.GetChild(0).GetComponent<TMP_Text>();
        }
        else if (isMulti)
        {
            txt = transform.GetComponentInChildren<TMP_Text>();

            if (gameObject.name == "Frame")
            {
                txt = transform.GetChild(0).GetComponent<TMP_Text>();
            }
        }
    }
    private void OnEnable()
    {
        image.sprite = DataManager.s_inst.ButtonImage;
        image.color = DataManager.s_inst.ButtonColor;
        if (isTextNeed)
            ChangeTextFont();
    }
    private void ChangeTextFont()
    {
        if (image.sprite.name == "Button_6" || image.color.CompareRGB(new Color32(107, 77, 255, 255)) 
            || image.color.CompareRGB(new Color32(166, 77, 255, 255)))
            txt.color = Color.white;
        else
            txt.color = new Color32(50, 50, 50, 255);
        if (gameObject.name == "Frame")
        {
            TMP_Text txt_2 = transform.GetChild(1).GetComponent<TMP_Text>();
            txt_2.color = txt.color;
        }
    }
}
