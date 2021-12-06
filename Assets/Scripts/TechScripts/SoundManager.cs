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
    void Awake()
    {
        DontDestroyOnLoad(this);

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
}
