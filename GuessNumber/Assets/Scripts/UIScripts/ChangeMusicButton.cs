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
        if (SoundManager.s_inst.MusicValueMute == 0)
            image.sprite = muteMusic;
    }
    private void OnMouseDown()
    {
        image.sprite = image.sprite.name == music.name ? muteMusic : music;
        SoundManager.s_inst.SwitchMusicVolume();
    }
}
