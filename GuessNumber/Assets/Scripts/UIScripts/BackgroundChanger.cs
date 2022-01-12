using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void ChangeColor(Color32 color)
    {
        image.color = color;
    }
}
