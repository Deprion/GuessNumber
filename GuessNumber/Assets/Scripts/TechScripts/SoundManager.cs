using System.Collections;
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
    public int MusicValueMute { private set; get; }
    void Awake()
    {
        DontDestroyOnLoad(this);
        s_inst = this;

        audioSourceMusic = GetComponent<AudioSource>();
        audioSourceMusic.volume = 0.5f;
        MusicValueMute = PlayerPrefs.GetInt("Music", 1);
        SwitchMusicVolume(MusicValueMute);

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
        StartCoroutine(raiseMusic(0));
    }
    public void SwitchMusicVolume()
    {
        audioSourceMusic.mute = !audioSourceMusic.mute;
        int temp = audioSourceMusic.mute == true ? 0 : 1;
        PlayerPrefs.SetInt("Music", temp);
        MusicValueMute = temp;
    }
    public void SwitchMusicVolume(int value)
    {
        audioSourceMusic.mute = value == 0 ? true : false;
    }
    private IEnumerator raiseMusic(float startVolume)
    {
        audioSourceMusic.volume = startVolume;
        while (audioSourceMusic.volume < 0.5f)
        {
            audioSourceMusic.volume += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
