using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public static Interface s_inst;
    private TMP_Text Balance;
    private void Start()
    {
        DontDestroyOnLoad(this);
        s_inst = this;
        SceneManager.activeSceneChanged += UpdateUI;
    }
    private void UpdateUI(Scene scenePrv, Scene SceneCur)
    {
        if (SceneCur.name == "MainMenuScene")
        {
            UpdateMoney();
        }
    }
    public void UpdateMoney()
    {
        if (Balance == null)
        {
            Balance = GameObject.FindGameObjectWithTag("Balance").GetComponent<TMP_Text>();
        }
        Balance.text = $"Монет: {DataManager.s_inst.Money}";
    }
}
