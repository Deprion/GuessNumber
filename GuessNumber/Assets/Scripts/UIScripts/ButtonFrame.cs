using UnityEngine;
using UnityEngine.UI;

public class ButtonFrame : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        image.sprite = DataManager.s_inst.ButtonImage;
        image.color = DataManager.s_inst.ButtonColor;
    }
}
