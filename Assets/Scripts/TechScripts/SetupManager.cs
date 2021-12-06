using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupManager : MonoBehaviour
{
    [SerializeField]
    private GameObject soundManager, dataManager, gameManager;
    private void Awake()
    {
        setupData();
        setupOther();
        StartCoroutine(loadScene());
    }

    private void setupData()
    {
        Instantiate(dataManager);
    }
    private void setupOther()
    {
        Instantiate(gameManager);
        Instantiate(soundManager);
    }
    private IEnumerator loadScene()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
