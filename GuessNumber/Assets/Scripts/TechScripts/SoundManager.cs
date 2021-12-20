using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] musicArray;
    [SerializeField]
    private AudioClip[] gameMusicArray;
    [SerializeField]
    private AudioSource audioSourceMusic;
    public static SoundManager s_inst;
    void Awake()
    {
        DontDestroyOnLoad(this);
        s_inst = this;

        audioSourceMusic = GetComponent<AudioSource>();
        audioSourceMusic.volume = 0.5f;

        SceneManager.activeSceneChanged += CheckMusic;
    }

    private void CheckMusic(Scene previous, Scene current)
    {
        if (current.buildIndex == 0) { }
        else if (current.buildIndex == 1)
        {
            audioSourceMusic.clip = musicArray[Random.Range(0, musicArray.Length)];
            audioSourceMusic.Play();
        }
        else
        {
            audioSourceMusic.clip = gameMusicArray[Random.Range(0, gameMusicArray.Length)];
            audioSourceMusic.Play();
        }
    }
    public void SwitchMusicVolume()
    {
        audioSourceMusic.mute = !audioSourceMusic.mute;
    }
}
