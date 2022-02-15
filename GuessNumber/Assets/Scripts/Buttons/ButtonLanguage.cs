using UnityEngine;
using UnityEngine.UI;

public class ButtonLanguage : MonoBehaviour
{
    [SerializeField]
    private Sprite ruIcon, usIcon;
    private Image img;
    private void Awake()
    {
        img = transform.GetChild(0).GetComponent<Image>();
        img.sprite = LanguageManager.inst.lang == SystemLanguage.Russian.ToString() ?
            ruIcon : usIcon;
    }
    private void OnMouseDown()
    {
        img.sprite = img.sprite == ruIcon ? usIcon : ruIcon;
        LanguageManager.inst.ChangeLang();
    }
}
