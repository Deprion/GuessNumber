using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupManager : MonoBehaviour
{
    [SerializeField]
    private GameObject soundManager;
    private void Awake()
    {
        setupMusic();
        StartCoroutine(loadScene());
    }
    private void setupMusic()
    {
        Instantiate(soundManager);
    }
    private IEnumerator loadScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
