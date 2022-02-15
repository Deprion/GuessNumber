using UnityEngine;
using TMPro;

public class LeaveGame : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private GameManager gm;
    private void OnEnable()
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GameManager").
            GetComponent<GameManager>();
        if (gm.CurrentLevel.Endless)
        {
            text.text = $"{LanguageManager.inst.GetString("text_leave_reward")}" +
                $": {NumberManager.s_inst.reward}";
        }
        else text.text = LanguageManager.inst.GetString("text_leave");
    }
    private void OnMouseDown()
    {
        if (gm.CurrentLevel.Endless)
            DataManager.s_inst.Money += NumberManager.s_inst.reward;
        if (gm.IsPlayerPlayed())
        {
             DataManager.s_inst.Money -= NumberManager.s_inst.loss;
        }
        SceneButtons.MainMenuBtn();
    }
}
