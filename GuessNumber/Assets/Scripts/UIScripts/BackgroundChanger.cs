using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        //image.color = Interface.s_inst.BackGroundColor;
    }
}
