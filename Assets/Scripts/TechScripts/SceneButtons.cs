using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    public static void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public static void PlayBotBtn()
    {
        SceneManager.LoadScene("PlayBotScene");
    }
    public void PlayOnlineBtn()
    {
        SceneManager.LoadScene("PlayOnlineScene");
    }
}
