using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicButton : MonoBehaviour
{
    [SerializeField]
    private Sprite music, muteMusic;
    private Image image;
    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        
    }
    private void OnMouseDown()
    {
        if (image.sprite.name == music.name)
        {
            image.sprite = muteMusic;
        }
        else 
        {
            image.sprite = music;
        }
        SoundManager.s_inst.SwitchMusicVolume();
    }
}