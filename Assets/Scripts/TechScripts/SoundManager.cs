using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] musicArray;
    [SerializeField]
    private AudioSource audioSourceMusic;
    void Awake()
    {
        DontDestroyOnLoad(this);

        audioSourceMusic = GetComponent<AudioSource>();

        SceneManager.activeSceneChanged += CheckMusic;
    }

    private void CheckMusic(Scene previous, Scene current)
    {
        if (current.name == "MainMenuScene")
        {
            audioSourceMusic.clip = musicArray[0];
            audioSourceMusic.Play();
        }
        else
        {
            audioSourceMusic.clip = musicArray[Random.Range(1, musicArray.Length)];
            audioSourceMusic.Play();
        }
    }
}
