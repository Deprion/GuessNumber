using UnityEngine;
using TMPro;

public class LeaveGame : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").
            GetComponent<GameManager>().CurrentLevel.Endless)
            text.text = $"Выйти?\nВы заберете монеты: {NumberManager.s_inst.reward}";
        else
            text.text = "Выйти?\nВы потеряете монеты, если угадывали.";
    }
    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").
            GetComponent<GameManager>().IsPlayerPlayed())
        {
            if (GameObject.FindGameObjectWithTag("GameManager").
            GetComponent<GameManager>().CurrentLevel.Endless)
                DataManager.s_inst.Money += NumberManager.s_inst.reward;
            else
                DataManager.s_inst.Money -= NumberManager.s_inst.loss;
        }
        SceneButtons.MainMenuBtn();
    }
}
