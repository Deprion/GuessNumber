using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    [SerializeField] private Image FrameBtn, ColorBtn;
    [SerializeField] private GameObject FramePanel, ColorPanel;
    private Color32 black = new Color32(153, 153, 153, 255);

    private void Start()
    {
        ChangeMenuFrame();
    }
    public void ChangeMenuFrame()
    {
        FrameBtn.color = Color.white;
        ColorBtn.color = black;
        FramePanel.SetActive(true);
        ColorPanel.SetActive(false);
    }

    public void ChangeMenuColor()
    {
        ColorBtn.color = Color.white;
        FrameBtn.color = black;
        ColorPanel.SetActive(true);
        FramePanel.SetActive(false);
    }
}
